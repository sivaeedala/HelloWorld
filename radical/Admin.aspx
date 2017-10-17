<%@ Page Title="" Language="C#" MasterPageFile="~/LandingPage.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <style type="text/css">
        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
        }

        .modalPopup {
            background-color: #FFFFFF;
            width: 500px;
            border: 3px solid rgba(112, 177, 113, 0.95);
            border-radius: 12px;
            padding: 5px 20px 5px 20px;
        }

            .modalPopup .header {
                background-color: #2FBDF1;
                height: 30px;
                color: White;
                line-height: 30px;
                text-align: center;
                font-weight: bold;
                border-top-left-radius: 6px;
                border-top-right-radius: 6px;
            }

            .modalPopup .body {
                min-height: 50px;
                line-height: 30px;
                text-align: center;
                font-weight: bold;
                padding: 4px 7px 2px 4px;
            }

            .modalPopup .footer {
                padding: 6px;
            }

            .modalPopup .yes, .modalPopup .no {
                /* height: 0px; */
                color: White;
                line-height: 23px;
                text-align: center;
                font-weight: bold;
                cursor: pointer;
                border-radius: 4px;
            }

            .modalPopup .yes {
                background-color: #468847;
                border: 2px solid #468847;
            }

            .modalPopup .no {
                background-color: #b75250;
                border: 1px solid #b75250;
            }

        .img {
            border-radius: 10px;
        }

        .ClosePopupCls {
            color: White;
            float: right;
            height: 12px;
            font-size: 10px;
            cursor: pointer;
            text-decoration: none;
        }

            .ClosePopupCls a:link {
                color: White;
                text-decoration: none;
            }

            .ClosePopupCls a:visited {
                color: White;
                text-decoration: none;
            }

            .ClosePopupCls a:hover {
                color: White;
                text-decoration: none;
            }
    </style>

    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div></div>
                <br />
                <div>
                    <div class="container-fluid">
                        <div class="row content">
                            <div class="row">
                                <div class="col-sm-4">
                                    <div class="well1">
                                        <h4>Approval</h4>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:LinkButton ID="lnkbtnBussiness" runat="server" CssClass="btn btn-primary btn-xs" OnClick="lnkbtnBussiness_Click">Bussiness:</asp:LinkButton>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblBussinessAppr" runat="server" Text="NA" CssClass="badge"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:LinkButton ID="lnkbtnDriver" runat="server" CssClass="btn btn-primary btn-xs" OnClick="lnkbtnDriver_Click">Driver :</asp:LinkButton>

                                                </td>
                                                <td>
                                                    <asp:Label ID="lblDriverAppr" runat="server" Text="NA" CssClass="badge"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="well2">
                                        <h4>Docket</h4>
                                        <p>
                                            1 Million
                                        </p>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="well3">
                                        <h4>Active Drivers</h4>
                                        <p>
                                            1 Million
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div>
                    <div id="divBussinessgrid" class="col-xs-12 col-sm-6 col-md-12" style="overflow-x: auto scroll">
                        <asp:Panel ID="pnlBussinessGrid" runat="server">
                            <h4>Bussiness</h4>
                            <asp:GridView ID="grdvwBussiness" runat="server" AutoGenerateColumns="False"
                                DataKeyNames="Id" OnRowCommand="grdvwBussiness_RowCommand" CssClass="table table-striped table-hover" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">

                                <Columns>
                                    <%--<asp:BoundField DataField="Id" HeaderText="Id"  />--%>
                                    <asp:BoundField DataField="Name" HeaderText="Name" />
                                    <asp:BoundField DataField="CompanyName" HeaderText="Company" />
                                    <asp:BoundField DataField="BussinessType" HeaderText="Bussiness" />
                                    <asp:BoundField DataField="website" HeaderText="website" />
                                    <asp:ButtonField ButtonType="Link" CommandName="Approve" Text="Approve" />
                                    <asp:ButtonField ButtonType="Link" CommandName="Reject" Text="Reject" />
                                    <asp:ButtonField ButtonType="Link" CommandName="AdditionalInfo" Text="AdditionalInfo" />
                                </Columns>

                                <FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>

                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="Black"></HeaderStyle>

                                <PagerStyle HorizontalAlign="Left" BackColor="White" ForeColor="#000066"></PagerStyle>

                                <RowStyle ForeColor="#000066"></RowStyle>

                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

                                <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>

                                <SortedAscendingHeaderStyle BackColor="#007DBB"></SortedAscendingHeaderStyle>

                                <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>

                                <SortedDescendingHeaderStyle BackColor="#00547E"></SortedDescendingHeaderStyle>
                            </asp:GridView>
                        </asp:Panel>
                    </div>



                    <div id="divDrivergrid" class="col-xs-12 col-sm-12 col-md-12">

                        <asp:Panel ID="pnlDriverGrid" runat="server">
                            h4>Driver</h4>
                            <asp:GridView ID="grdvwDriver" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                                OnRowCommand="grdvwDriver_RowCommand" CssClass="table table-striped table-hover "
                                CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                                <Columns>
                                    <%--<asp:BoundField DataField="Id" HeaderText="Id" Visible="false" />--%>
                                    <asp:BoundField DataField="Name" HeaderText="Name" />

                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            DriverLicense
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkgrdvwDriverDL" runat="server" CommandName="DriverLicense" Text="DriverLicense" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            TransitInsurance
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkgrdvwDriverTI" runat="server" CommandName="TransitInsurance" Text="TransitInsurance" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            CourierInsurance
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkgrdvwDriverCI" runat="server" CommandName="CourierInsurance" Text="CourierInsurance" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:ButtonField ButtonType="Link" CommandName="Approve" Text="Approve" />
                                    <asp:ButtonField ButtonType="Link" CommandName="Reject" Text="Reject" />
                                    <asp:ButtonField ButtonType="Link" CommandName="AdditionalInfo" Text="AdditionalInfo" />
                                </Columns>
                                <FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>

                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="Black"></HeaderStyle>

                                <PagerStyle HorizontalAlign="Left" BackColor="White" ForeColor="#000066"></PagerStyle>

                                <RowStyle ForeColor="#000066"></RowStyle>

                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

                                <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>

                                <SortedAscendingHeaderStyle BackColor="#007DBB"></SortedAscendingHeaderStyle>

                                <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>

                                <SortedDescendingHeaderStyle BackColor="#00547E"></SortedDescendingHeaderStyle>
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                </div>
                <asp:LinkButton ID="lnkFake" runat="server"></asp:LinkButton>
                <asp:LinkButton ID="lnkImage" runat="server"></asp:LinkButton>

                <div id="panelShow">
                    <asp:Panel ID="pnlshow" runat="server" CssClass="modalPopup">

                        <table class="table">
                            <tr>
                                <td>
                                    <asp:Label ID="lblId" runat="server" Text="Id" CssClass="col-lg-2 control-label"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtpnlshwId" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblName" runat="server" Text="Name" CssClass="col-lg-2 control-label"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtpnlshwName" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="lblStatus" runat="server" Text="Status" CssClass="col-lg-2 control-label"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtStatus" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblInfo" runat="server" Text="Reason" CssClass="col-lg-2 control-label"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtReason" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                </td>
                                <br />

                            </tr>
                            <tr align="right">
                                <td></td>
                                <td>
                                    <asp:Button ID="btnUpdate" runat="server" Text="Update Status" OnClick="btnUpdate_Click" CssClass="btn btn-primary yes" />
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-default no" />
                                </td>

                            </tr>
                            <span>
                                <asp:Label ID="lblValidMsg" runat="server" Text="" Style="color: red" CssClass="control-label"></asp:Label>
                            </span>

                        </table>
                    </asp:Panel>
                </div>
                <div id="divImage" runat="server">
                    <asp:Panel ID="PnlImage" runat="server" CssClass="modalPopup">
                        <table class="table">
                            <tr>
                                <td>
                                    <asp:Image runat="server" ID="imgTest" Width="400" Height="250"></asp:Image>
                                </td>
                            </tr>
                            <tr align="right">

                                <td>
                                    <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-default no" />
                                </td>

                            </tr>
                        </table>
                    </asp:Panel>
                </div>

                <cc1:ModalPopupExtender ID="popup" runat="server" DropShadow="false"
                    PopupControlID="panelShow" TargetControlID="lnkFake"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>

                <cc1:ModalPopupExtender ID="popupImage" runat="server" DropShadow="false"
                    PopupControlID="PnlImage" TargetControlID="lnkImage"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>


</asp:Content>


