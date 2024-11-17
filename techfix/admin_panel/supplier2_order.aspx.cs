using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace techfix.admin_panel
{
    public partial class supplier2_order : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
                LoadProductsByCategory(1); // Load default category  on page load

                if (Session["SelectedItems"] == null)
                {
                    Session["SelectedItems"] = new List<Product>();
                }
            }
        }

        [Serializable] 
        public class Product
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }  
            public decimal TotalPrice => Price * Quantity;
        }

        string connectionString = WebConfigurationManager.ConnectionStrings["techfixdbConnectionString"].ConnectionString;

        private void LoadCategories()
        {
            string query = "SELECT id, category_name FROM s2category";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    try
                    {
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        RepeaterCategories.DataSource = reader;
                        RepeaterCategories.DataBind();
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('Error loading categories: " + ex.Message + "');</script>");
                    }
                }
            }
        }

        private void LoadProductsByCategory(int categoryId)
        {
            string query = "SELECT id, product_name, image, price, description, qty FROM s2product WHERE category_id = @CategoryId";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                    try
                    {
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        RepeaterProducts.DataSource = reader;
                        RepeaterProducts.DataBind();

                        List<Product> selectedItems = Session["SelectedItems"] as List<Product>;
                        if (selectedItems != null)
                        {
                            foreach (RepeaterItem item in RepeaterProducts.Items)
                            {
                                CheckBox checkbox = (CheckBox)item.FindControl("SelectProductCheckbox");
                                int productId = Convert.ToInt32(((HiddenField)item.FindControl("HiddenProductId")).Value);

                                if (selectedItems.Exists(p => p.ProductId == productId))
                                {
                                    checkbox.Checked = true;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('Error loading products: " + ex.Message + "');</script>");
                    }
                }
            }
        }

        protected string GetStockStatus(object qty)
        {
            int quantity = Convert.ToInt32(qty);
            return quantity > 0 ? "In Stock" : "Out of Stock";
        }

        protected void CategoryTab_Click(object sender, EventArgs e)
        {
            LinkButton clickedButton = (LinkButton)sender;
            int categoryId = Convert.ToInt32(clickedButton.CommandArgument);
            LoadProductsByCategory(categoryId);
        }

        protected void SelectProductCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            RepeaterItem item = (RepeaterItem)checkbox.NamingContainer;
            int productId = Convert.ToInt32(((HiddenField)item.FindControl("HiddenProductId")).Value);
            string productName = ((Label)item.FindControl("ProductNameLabel")).Text;
            decimal price = Convert.ToDecimal(((Label)item.FindControl("ProductPriceLabel")).Text);

            List<Product> selectedItems = Session["SelectedItems"] as List<Product>;

            if (checkbox.Checked)
            {
                Product newProduct = new Product
                {
                    ProductId = productId,
                    ProductName = productName,
                    Price = price,
                    Quantity = 1 // Default quantity when selected
                };

                selectedItems.Add(newProduct);
            }
            else
            {
                selectedItems.RemoveAll(p => p.ProductId == productId);
            }

            Session["SelectedItems"] = selectedItems;
            BindSelectedProducts();
        }

        protected void IncreaseQty_Click(object sender, EventArgs e)
        {
            Button increaseButton = (Button)sender;
            int productId = Convert.ToInt32(increaseButton.CommandArgument);
            List<Product> selectedItems = Session["SelectedItems"] as List<Product>;

            Product product = selectedItems.Find(p => p.ProductId == productId);
            if (product != null)
            {
                product.Quantity++;
            }

            BindSelectedProducts();
        }

        protected void DecreaseQty_Click(object sender, EventArgs e)
        {
            Button decreaseButton = (Button)sender;
            int productId = Convert.ToInt32(decreaseButton.CommandArgument);
            List<Product> selectedItems = Session["SelectedItems"] as List<Product>;

            Product product = selectedItems.Find(p => p.ProductId == productId);
            if (product != null && product.Quantity > 1)
            {
                product.Quantity--;
            }
            else if (product != null && product.Quantity == 1)
            {
                selectedItems.Remove(product);
            }

            BindSelectedProducts();
        }

        private void BindSelectedProducts()
        {
            List<Product> selectedItems = Session["SelectedItems"] as List<Product>;
            RepeaterSelectedProducts.DataSource = selectedItems;
            RepeaterSelectedProducts.DataBind();

            // Calculate the total price
            decimal totalPrice = 0;
            foreach (var item in selectedItems)
            {
                totalPrice += item.TotalPrice;
            }

            TotalPriceLabel.Text = totalPrice.ToString("F2"); // Display total price
        }

        protected void AddToQuoteButton_Click(object sender, EventArgs e)
        {
            // Redirect to the quote page
            Response.Redirect("s2quote.aspx");
        }

        // Add the following code to your supplier1_order.aspx.cs file

        protected void PlaceOrderButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("s2place_order.aspx");
        }


    }
}

