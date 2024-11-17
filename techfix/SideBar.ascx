<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SideBar.ascx.cs" Inherits="techfix.SideBar" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

    <title>TechFix - Repair Section</title>
    <link href="css/styles.css" rel="stylesheet" />
    <link href="css/repair.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-icons/1.5.0/font/bootstrap-icons.min.css" rel="stylesheet">
</head>
<body style="background-color: #101010;">   
      
    <!-- Sidebar -->
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
                   
                </div>
            </div>
        </div>
    
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>