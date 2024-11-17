using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace techfix.admin_panel
{
    public partial class s2quote : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindQuoteItems();
            }
        }

        private void BindQuoteItems()
        {
            List<supplier2_order.Product> selectedItems = Session["SelectedItems"] as List<supplier2_order.Product>;
            if (selectedItems != null && selectedItems.Count > 0)
            {
                RepeaterQuoteItems.DataSource = selectedItems;
                RepeaterQuoteItems.DataBind();

                decimal totalPrice = selectedItems.Sum(item => item.TotalPrice);
                TotalPriceLabel.Text = totalPrice.ToString("F2");
            }
            else
            {
                TotalPriceLabel.Text = "0.00"; 
            }
        }

        protected override void LoadViewState(object savedState)
        {
            base.LoadViewState(savedState);
            if (Request["__EVENTTARGET"] == RepeaterQuoteItems.UniqueID &&
                Request["__EVENTARGUMENT"] != null)
            {
                if (int.TryParse(Request["__EVENTARGUMENT"], out int productId))
                {
                    RemoveProductFromQuote(productId);
                }
            }
        }

        private void RemoveProductFromQuote(int productId)
        {
            List<supplier2_order.Product> selectedItems = Session["SelectedItems"] as List<supplier2_order.Product>;
            if (selectedItems != null)
            {
                selectedItems.RemoveAll(p => p.ProductId == productId);
                Session["SelectedItems"] = selectedItems; 
                BindQuoteItems(); 
            }
        }

        protected void DownloadQuoteButton_Click(object sender, EventArgs e)
        {
            // Create PDF document
            using (MemoryStream ms = new MemoryStream())
            {
                using (PdfWriter writer = new PdfWriter(ms)) 
                {
                    using (PdfDocument pdf = new PdfDocument(writer))
                    {
                        Document document = new Document(pdf);
                        document.Add(new Paragraph("Quote Details").SetFontSize(20).SetBold());

                        List<supplier1_order.Product> selectedItems = Session["SelectedItems"] as List<supplier1_order.Product>;
                        if (selectedItems != null)
                        {
                            foreach (var item in selectedItems)
                            {
                                document.Add(new Paragraph($"{item.ProductName} - ${item.Price} x {item.Quantity} = ${item.TotalPrice}"));
                            }

                            decimal totalPrice = selectedItems.Sum(i => i.TotalPrice);
                            document.Add(new Paragraph($"Total Price: ${totalPrice:F2}").SetBold());
                        }

                        document.Close();
                    }
                }

                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", $"attachment; filename=Quote_{DateTime.Now:yyyyMMddHHmmss}.pdf");
                Response.BinaryWrite(ms.ToArray());
                Response.End();
            }
        }

    }
}
