<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pcbuild.aspx.cs" Inherits="techfix.repair" %>
<%@ Register Src="~/NavBar.ascx" TagPrefix="uc" TagName="NavBar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head>

    <title>TechFix - Repair Section</title>
    <link href="css/styles.css" rel="stylesheet" />
    <link href="css/repair.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-icons/1.5.0/font/bootstrap-icons.min.css" rel="stylesheet">

</head>

<body style="background-color: #101010;">   
 <uc:NavBar ID="NavBar1" runat="server" />
    <div class="container-fluid" style="margin-top: 80px;">
       <div class="row">
          <div class="col-md-3">
              <div class="sidebar bg-dark text-white p-3">
                 <h5>Categories</h5>
                    <asp:ListView ID="lvCategories" runat="server">
                        <ItemTemplate>
                            <div class="category-item">
                            <!-- Image and Name for Category -->
                                 <img src='<%# "img/" + Eval("image_name") %>' 
                                  alt='<%# Eval("category_name") %>' 
                                  style="width: 30px; height: 30px;" />
                                <p>
                                    <!-- Clickable Link to item.aspx with category id -->
                                    <a href='item.aspx?category_id=<%# Eval("id") %>'>
                                        <%# Eval("category_name") %>
                                    </a>
                                </p>
                            </div>
                         </ItemTemplate>
                     </asp:ListView>
                    </div>
                </div>
             <div class="col-md-9">
                    <!-- Repair section content can go here -->
                    <h2 class="text-white">Build your Dream PC </h2>
                    <p class="text-white">Details about repair services...</p>
                    <img src='https://mapmodnews.com/wp-content/uploads/2021/11/6e8bae1b4eed830cc755df65ac75312ce81e4554-e1637905616462.jpeg'>
                </div>
            </div>
        </div>
    
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>








