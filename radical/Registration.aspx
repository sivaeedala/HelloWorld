<%@ Page Title="" Language="C#" MasterPageFile="~/Radical.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
       
					<h2>Registration <small>Radical Courier Service</small></h2>
					<hr class="colorgraph" />
					<div class="input-group">						
						<asp:RadioButton ID="rb_company" runat="server" BorderStyle="None" GroupName="rb_User" CssClass="radio-inline" Text="Business" Height="20px" OnCheckedChanged="rb_company_CheckedChanged" AutoPostBack="True" />
                        <asp:RadioButton ID="rb_personal" runat="server" BorderStyle="None" GroupName="rb_User" CssClass="radio-inline" Text="Non-Business (Personal)" OnCheckedChanged="rb_personal_CheckedChanged" AutoPostBack="True" Checked="True" />
						<asp:RadioButton ID="rb_driver" runat="server" BorderStyle="None" GroupName="rb_User" CssClass="radio-inline" Text="Driver" OnCheckedChanged="rb_driver_CheckedChanged" AutoPostBack="True" />

					</div>					
					<hr />
					
					<div id="reg">
						<div class="container" >
							<%-- Row First Name & Last Name Begins--%>
						
							<div class="row">
								<%-- First Column --%>
								<div class="col-xs-12 col-sm-6 col-md-6">
									<span class="label label-success">First Name</span>
									<div class="input-group form-group">
										<span class="input-group-addon" style="background-color: #3A57AF"><i class="glyphicon glyphicon-user" style="color: white"></i></span>
										
										<asp:TextBox ID="tx_fname" runat="server" class="form-control" placeholder="First Name" ></asp:TextBox>
									</div>
								</div>
								<%-- Second Column --%>
								<div class="col-xs-12 col-sm-6 col-md-6">
                                    <span class="label label-success">Last Name</span>
									<div class="input-group form-group">
										<span class="input-group-addon" style="background-color: #3A57AF"><i class="glyphicon glyphicon-user" style="color: white"></i></span>
										<asp:TextBox ID="tx_lname" runat="server" class="form-control" placeholder="Last Name" ></asp:TextBox>
									</div>
								</div>

							</div>
							
							<%-- Row email & dob--%>
							<div class="row">
								<div class="col-xs-12 col-sm-6 col-md-6">
									<span class="label label-success">Email</span><span class="label label-info">[Email will be used as your username]</span>
									<div class="input-group form-group">
										<span class="input-group-addon" style="background-color: #3A57AF"><i class="glyphicon glyphicon-envelope" style="color: white"></i></span>
										<asp:TextBox ID="tx_email" runat="server" class="form-control" placeholder="Email"></asp:TextBox>
									</div>
								</div>
								<div class="col-xs-12 col-sm-6 col-md-6">
                                    <span class="label label-success">Date of Birth</span>
									<div class="input-group form-group">
										<span class="input-group-addon" style="background-color: #3A57AF"><i class="glyphicon glyphicon-calendar" style="color: white"></i></span>
										<asp:TextBox ID="tx_dob" runat="server" class="form-control" placeholder="Date of Birth"></asp:TextBox>
									</div>
								</div>
							</div>

							<%-- Row Password & Confirm Password--%>
							<div class="row">
								<%-- Password Column --%>
								<div class="col-xs-12 col-sm-6 col-md-6">
                                    <span class="label label-success">Password</span>
									<div class="input-group form-group">
										<span class="input-group-addon" style="background-color: #3A57AF"><i class="glyphicon glyphicon-lock" style="color: white"></i></span>
										<asp:TextBox ID="tx_password" runat="server" class="form-control" placeholder="Password" MaxLength="8" TextMode="Password"></asp:TextBox>
									</div>
								</div>
								<%-- Confirm Password Column --%>
								<div class="col-xs-12 col-sm-6 col-md-6">
                                    <span class="label label-success">Confirm Password</span>
									<div class="input-group form-group">
										<span class="input-group-addon" style="background-color: #3A57AF"><i class="glyphicon glyphicon-lock" style="color: white"></i></span>
										<asp:TextBox ID="tx_confirmpassword" runat="server" class="form-control" placeholder="Confirm Password" MaxLength="8" TextMode="Password"></asp:TextBox>
									</div>
								</div>								
							</div>

							<%-- Row Mobile & Phone Number--%>
							<div class="row">
								<%-- Mobile Column --%>
								<div class="col-xs-12 col-sm-6 col-md-6">
                                    <span class="label label-success">Mobile</span>
									<div class="input-group form-group">
										<span class="input-group-addon" style="background-color: #3A57AF"><i class="glyphicon glyphicon-phone" style="color: white"></i></span>
										<asp:TextBox ID="tx_mobile" runat="server" class="form-control" placeholder="Mobile" MaxLength="10" TextMode="Number"></asp:TextBox>
									</div>
								</div>
								<%-- Phone Number Column --%>
								<div class="col-xs-12 col-sm-6 col-md-6">
                                    <span class="label label-success">Telephone</span>
									<div class="input-group form-group">
										<span class="input-group-addon" style="background-color: #3A57AF"><i class="glyphicon glyphicon-phone-alt" style="color: white"></i></span>
										<asp:TextBox ID="tx_telephone" runat="server" class="form-control" placeholder="Telephone" MaxLength="11" TextMode="Number"></asp:TextBox>
									</div>
								</div>								
							</div>

						
							<%-- Address Details--%>
							<h3> Address Details</h3>
							<hr />
							<%-- Row Add1 & Add2 --%>
							
							<div class="row">
								<%-- First Column --%>
								<div class="col-xs-12 col-sm-6 col-md-6">
                                    <span class="label label-success">Address Line1</span>
									<div class="input-group form-group">
										<span class="input-group-addon" style="background-color: #3A57AF"><i class="glyphicon glyphicon-book" style="color: white"></i></span>
										<asp:TextBox ID="tx_addr1" runat="server" class="form-control" placeholder="AddressLine1"></asp:TextBox>
									</div>
								</div>
								<%-- Second Column --%>
								<div class="col-xs-12 col-sm-6 col-md-6">
                                    <span class="label label-success">Address Line2</span>
									<div class="input-group form-group">
										<span class="input-group-addon" style="background-color: #3A57AF"><i class="glyphicon glyphicon-road" style="color: white"></i></span>
										<asp:TextBox ID="tx_addr2" runat="server" class="form-control" placeholder="AddressLine2"></asp:TextBox>
									</div>
								</div>
							</div>
							<%---Row town & County---%>
							<%-- First Column --%>
							<div class="row">
								<div class="col-xs-12 col-sm-6 col-md-6">
                                    <span class="label label-success">Town</span>
									<div class="input-group form-group">
										<span class="input-group-addon" style="background-color: #3A57AF"><i class="glyphicon glyphicon-home" style="color: white"></i></span>
										<asp:TextBox ID="tx_town" runat="server" class="form-control" placeholder="Town"></asp:TextBox>
									</div>
								</div>
								<%--Second Column --%>
								<div class="col-xs-12 col-sm-6 col-md-6">
                                    <span class="label label-success">County</span>
									<div class="input-group form-group">
										<span class="input-group-addon" style="background-color: #3A57AF"><i class="glyphicon glyphicon-leaf" style="color: white"></i></span>
										<asp:TextBox ID="tx_county" runat="server" class="form-control" placeholder="County"></asp:TextBox>
									</div>
								</div>
							</div>
							<%---Row Country & Postcode---%>

							<%-- First Column --%>
							<div class="row">
								<div class="col-xs-12 col-sm-6 col-md-6">
                                    <span class="label label-success">Country</span>
									<div class="input-group form-group">
										<span class="input-group-addon" style="background-color: #3A57AF"><i class="glyphicon glyphicon-flag" style="color: white"></i></span>
										<asp:TextBox ID="tx_country" runat="server" class="form-control" placeholder="Country"></asp:TextBox>
									</div>
								</div>
								<%--Second Column --%>
								<div class="col-xs-12 col-sm-6 col-md-6">
                                    <span class="label label-success">Postcode</span>
									<div class="input-group form-group">
										<span class="input-group-addon" style="background-color: #3A57AF"><i class="glyphicon glyphicon-search" style="color: white"></i></span>
										<asp:TextBox ID="tx_postcode" runat="server" class="form-control" placeholder="Postcode" MaxLength="15"></asp:TextBox> 
									</div> 
								</div> 

							</div>						
							<%-- This area shows the information about the company details, if the user selected the company radio button--%>					
							<div id="id_company" runat ="server">
							<h4> Company Details</h4>
							<hr />
								<%-- Row of Company Name and Website --%>
								<div class="row">
									<%-- Company Name --%>
									<div class="col-xs-12 col-sm-6 col-md-6">
                                        <span class="label label-success">Company Name</span>
										<div class="input-group form-group">
											<span class="input-group-addon" style="background-color: #3A57AF"><i class="glyphicon glyphicon-book" style="color: white"></i></span>
											<asp:TextBox ID="tx_companyname" runat="server" class="form-control" placeholder="Company Name"></asp:TextBox>
										</div>
									</div>
									<%-- Company website --%>
									<div class="col-xs-12 col-sm-6 col-md-6">
                                        <span class="label label-success">Company Website</span>	
										<div class="input-group form-group">
											<span class="input-group-addon" style="background-color: #3A57AF"><i class="glyphicon glyphicon-globe" style="color: white"></i></span>
											<asp:TextBox ID="tx_website" runat="server" class="form-control" placeholder="Website"></asp:TextBox>
										</div>
									</div>								
								</div>

								 <%--Row of Business Type and Upload doc1 --%>
								<div class="row">
									<%--Business Type--%>
									<div class="col-xs-12 col-sm-6 col-md-6">
										<div class="input-group form-group">
											<div>
												<span class="label label-primary">(Example: Courier Company, Construction etc)</span>											
											</div>
											<div class="input-group form-group">											
												<span class="input-group-addon" style="background-color: #3A57AF"><i class="glyphicon glyphicon-signal" style="color: white"></i></span>
												<asp:TextBox ID="tx_businesstype" runat="server" class="form-control" placeholder="Business Type"></asp:TextBox>											
											</div>
										</div>
									</div>
									<%-- upload doc1 --%>
																
								</div>
								<%-- Row of Doc 2 & 3 to Upload --%>													
					</div>
							<%-- End of Company Details--%>

							<%-- This area shows the information about the Driver details, if the user selected the Driver radio button--%>
							<div id="id_driver" runat="server">
							<h4> Driver Details</h4>
							<hr />

							<%-- Row of Doc 1 (Driver Licence Photocopy) & 2 (V5 Docs) to Upload --%>
							<div class="row">
								<%-- Driver Licence Photocopy --%>
								<div class="col-xs-12 col-sm-6 col-md-6">
									<div class="input-group form-group">
										<%-- Label Driver Licence Photocopy --%>
										<span class="label label-success">Driver Licence Photocopy</span>										
										<%-- upload Driver Licence Photocopy --%>
										<%--<span class="input-group-addon" style="background-color: #3A57AF"><i class="glyphicon glyphicon-lock" style="color: white"></i></span>--%>
										<asp:FileUpload ID="fu_driverlicence" runat="server" class="form-control" placeholder="fu_driverlicence" />		
									</div>
								</div>
                                <%--Courier Insurance --%>
								<div class="col-xs-12 col-sm-6 col-md-6">
									<div class="input-group form-group">
										<%-- Label Courier Insurance Photocopy --%>
										<span class="label label-success">Courier Insurance</span>										
										<%-- upload Courier Insurance Photocopy --%>
										<%--<span class="input-group-addon" style="background-color: #3A57AF"><i class="glyphicon glyphicon-lock" style="color: white"></i></span>--%>
										<asp:FileUpload ID="fu_courierinsurance" runat="server" class="form-control" placeholder="Upload Doc2" />	
									</div>
								</div>																
							</div>						
							<%-- Row of Doc 1 (Goods-In Transit Insurance) to Upload & 2 (Payment Plan)  --%>
							<div class="row">
								<%-- Goods-In Transit Insurance --%>
								<div class="col-xs-12 col-sm-6 col-md-6">
									<div class="input-group form-group">
										<%-- Label Goods-In Transit Insurance --%>
										<span class="label label-danger">[Optional]</span> <span class="label label-success"> Goods-In Transit Insurance</span>										
										<%-- upload Goods-In Transit Insurance --%>
										<%--<span class="input-group-addon" style="background-color: #3A57AF"><i class="glyphicon glyphicon-lock" style="color: white"></i></span>--%>
										<asp:FileUpload ID="fu_goodsintransit" runat="server" class="form-control" placeholder="Goods-In Transit Insurance" />		
									</div>
								</div>								
								<%--Payment Rate --%>
								<div class="col-xs-12 col-sm-6 col-md-6">
									<div class="input-group form-group">
										<div>
											<%-- Label Payment Rate --%>
											<span class="label label-success">Payment rate</span>									
										</div>
										<div class="input-group form-group">
										<%-- Payment Rate --%>										
										<span class="input-group-addon" style="background-color: #3A57AF"><i class="glyphicon glyphicon-gbp" style="color: white"></i></span>
										<asp:TextBox ID="tx_payment" runat="server" class="form-control" placeholder="Payment Rate"></asp:TextBox>											
										</div>
									</div>
								</div>								
							</div>
						</div>
							<div id="id_registerButton">
								<asp:Button ID="btn_reg" runat="server" Text="Register" OnClick="btn_Click" CssClass="btn btn-primary" /> | <small>By clicking Register you agree on our <a href="#">terms and condition</a></small>
						</div>
							<br />
							<div  id="id_status" class="row"  runat ="server"> <%---button approve,Reject div-----%>
								<div class="input-group form-group">								
									<div class="col-sm-4 col-md-4 col-xs-4 col-lg-4">
									  <asp:Button ID="btn_reject" runat="server" Text="Reject" OnClick="btn_Click" CssClass="btn btn-danger" />										
									</div>	
									<div class="col-sm-4 col-md-4 col-xs-4 col-lg-4">
									  <asp:Button ID="btn_disable" runat="server" Text="Disable" OnClick="btn_Click" CssClass="btn btn-warning"/>
									</div>
									<div class="col-sm-4 col-md-4 col-xs-4 col-lg-4">									  
									  <asp:Button ID="btn_approve" runat="server" Text="Approve" OnClick="btn_Click" CssClass="btn btn-success" />
									</div>
								</div>
							</div><%-- end of id_status Div--%>

						</div>	<%-- Container Div--%>						
					</div> <%-- end of Reg Div--%>
					
              <div class="modal fade" id="myModal">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title">
                                Information</h4>
                        </div>
                        <div class="modal-body" style="text-align:center">                           
                           <h1>  <asp:Label ID="lb_reg_result" runat="server" Font-Size="Small" ForeColor="SteelBlue"></asp:Label>  </h1>   
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">
                                Close</button>                                                                                    
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
    
            <!-- /.modal -->  
<%--Hidden Button for Message Selection --%>
                <button type="button" style="display: none;" id="btnShowPopup" class="btn btn-primary btn-lg"
                data-toggle="modal" data-target="#myModal">
                Launch demo modal</button>
              <%--  <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click1" /> Info Button commented Santhosh	 --%>
	<br />
	<br />


<!--Validation-->
	   <script>

		   var picker = new Pikaday(
			   {
				   field: document.getElementById('tx_dob'),
				   firstDay: 1,
				   minDate: new Date(),
				   maxDate: new Date(2020, 12, 31),
				   yearRange: [2000, 2020]
               });
                     
    </script>

     <script type= "text/javascript">
         function ShowPopup() {
              $("#btnShowPopup").click();
         }

         $(document).ready(function () {
             for (i = 1; i < 6; i++)
             {
                 if (i != 4) {
                     $('#' + i).removeClass('active');
                 }
                 else {
                     $('#' + 4).addClass('active');
                 }
             }

             $("#<%=tx_postcode.ClientID%>").keypress(function (e) {
                 //if the letter is not digit then display error and don't type anything
                 if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                     //display error message
                     $("#errmsg").html("Digits Only").show().fadeOut("slow");
                     return false;
                 }
             });
         });
    </script> 
</asp:Content>

