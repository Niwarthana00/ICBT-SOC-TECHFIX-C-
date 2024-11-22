<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SideBar.ascx.cs" Inherits="techfix.SideBar" %>

 
      
    <!-- Sidebar -->
    <div class="container">
       <div class="row">
          <div class="col-12">
              <div class="sidebar bg-dark text-white p-3 fixed-remove">
                 <h5>Categories</h5>
                    <asp:ListView ID="lvCategories" runat="server">
                        <ItemTemplate>
                            <div class="category-item">

                            <!-- Image and Name for Category -->
                                 <img src='<%# "img/" + Eval("image_name") %>' 
                                  alt='<%# Eval("category_name") %>' 
                                  style="width: 30px; height: 30px;" />
                                <p>

                                    <a href='item.aspx?category_id=<%# Eval("id") %>'>
                                        <%# Eval("category_name") %>
                                    </a>
                                </p>
                            </div>
                         </ItemTemplate>
                     </asp:ListView>
                    </div>
                </div>
            </div>
        </div>
    
