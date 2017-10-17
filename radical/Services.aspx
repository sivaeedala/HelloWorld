<%@ Page Title="" Language="C#" MasterPageFile="~/Radical.master" AutoEventWireup="true" CodeFile="Services.aspx.cs" Inherits="Services" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<!--Validation-->
	   <script> 
             $(document).ready(function () {
             for (i = 1; i < 6; i++)
             {
                 if (i != 3) {
                     $('#' + i).removeClass('active');
                 }
                 else {
                     $('#' + 3).addClass('active');
                 }
             }
         });
    </script>
</asp:Content>

