<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="techfix.admin_panel.dashboard" %>
<%@ Register Src="admin_sidebar.ascx" TagName="Sidebar" TagPrefix="uc1" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <title>Customer Orders</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/sidebar.css" rel="stylesheet" />
    <style>
        .main-content {
            margin-left: 250px; /* Adjust based on sidebar width */
            padding: 20px;
        }
        table {
            width: 100%;
        }
        th, td {
            padding: 10px;
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-- Add Sidebar -->
            <uc1:Sidebar ID="Sidebar" runat="server" />

         
        </div>


        <script>
    document.addEventListener('keydown', function(event) {
        if (event.key === 'ArrowRight') {
            $('.collapse').collapse('show'); // Expand menus
        } else if (event.key === 'ArrowLeft') {
            $('.collapse').collapse('hide'); // Collapse menus
        }
    });
        </script>
    </form>
    
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</body>
</html>
