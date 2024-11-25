using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace techfix
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AddItemToCart();
                BindCartItems();
            }
        }

        private void AddItemToCart()
        {
            string itemName = Request.QueryString["item"];
            string qtyStr = Request.QueryString["qty"];
            string priceStr = Request.QueryString["price"];
            string image = Request.QueryString["image"];

            if (!string.IsNullOrEmpty(itemName) && !string.IsNullOrEmpty(qtyStr) && !string.IsNullOrEmpty(priceStr))
            {
                int qty = int.Parse(qtyStr);
                decimal price = decimal.Parse(priceStr);

                List<CartItem> cartItems = Session["Cart"] as List<CartItem> ?? new List<CartItem>();

                CartItem existingItem = cartItems.FirstOrDefault(item => item.ItemName == itemName);
                if (existingItem != null)
                {
                    existingItem.Quantity += qty;
                    existingItem.TotalPrice = existingItem.Quantity * existingItem.Price;
                }
                else
                {
                    cartItems.Add(new CartItem
                    {
                        ItemName = itemName,
                        Quantity = qty,
                        Price = price,
                        TotalPrice = qty * price,
                        Image = image
                    });
                }

                Session["Cart"] = cartItems;
            }
        }

        private void BindCartItems()
        {
            List<CartItem> cartItems = Session["Cart"] as List<CartItem>;

            if (cartItems != null && cartItems.Count > 0)
            {
                lvCartItems.DataSource = cartItems;
                lvCartItems.DataBind();

                decimal grandTotal = cartItems.Sum(item => item.TotalPrice);
                grandTotalLabel.Text = "RS. " + grandTotal.ToString("0.00");
            }
            else
            {
                lvCartItems.DataSource = null;
                lvCartItems.DataBind();

                grandTotalLabel.Text = "RS. 0.00";
            }
        }

        protected void RemoveItem_Click(object sender, EventArgs e)
        {
            List<CartItem> cartItems = Session["Cart"] as List<CartItem>;

            if (cartItems != null)
            {
                string itemName = ((System.Web.UI.WebControls.LinkButton)sender).CommandArgument;

                CartItem itemToRemove = cartItems.FirstOrDefault(item => item.ItemName == itemName);
                if (itemToRemove != null)
                {
                    cartItems.Remove(itemToRemove);

                    if (cartItems.Count == 0)
                    {
                        Session["Cart"] = null;
                    }
                    else
                    {
                        Session["Cart"] = cartItems;
                    }

                    BindCartItems();
                }
            }
        }

        protected void Checkout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Checkout.aspx");
        }

        protected void back_Click(object sender, EventArgs e)
        {
            // Redirect to the previous page (or any other page, e.g., home.aspx)
            Response.Redirect("home.aspx");
        }

        protected void DownloadQuotation_Click(object sender, EventArgs e)
        {
            List<CartItem> cartItems = Session["Cart"] as List<CartItem>;

            if (cartItems != null && cartItems.Count > 0)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    Document document = new Document();
                    PdfWriter.GetInstance(document, ms);
                    document.Open();

                    // Title
                    document.Add(new Paragraph("Quotation"));
                    document.Add(new Paragraph("\n"));

                    // Table to display cart items
                    PdfPTable table = new PdfPTable(4);
                    table.AddCell("Item Name");
                    table.AddCell("Quantity");
                    table.AddCell("Price");
                    table.AddCell("Total");

                    foreach (var item in cartItems)
                    {
                        table.AddCell(item.ItemName);
                        table.AddCell(item.Quantity.ToString());
                        table.AddCell(item.Price.ToString("0.00"));
                        table.AddCell(item.TotalPrice.ToString("0.00"));
                    }

                    document.Add(table);

                    // Grand Total
                    document.Add(new Paragraph("\n"));
                    decimal grandTotal = cartItems.Sum(item => item.TotalPrice);
                    document.Add(new Paragraph("Grand Total: RS. " + grandTotal.ToString("0.00")));

                    document.Close();

                    // Send the PDF file to the browser
                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=quotation.pdf");
                    Response.BinaryWrite(ms.ToArray());
                    Response.End();
                }
            }
        }

        public class CartItem
        {
            public string ItemName { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            public decimal TotalPrice { get; set; }
            public string Image { get; set; }
        }
    }
}
