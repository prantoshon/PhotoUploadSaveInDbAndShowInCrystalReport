<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EmployeeInfo.Default.Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EmployeeInfo</title>
        <meta charset="utf-8">
    <meta http-equiv="x-ua-compatible" content="ie=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
  
    <link rel="stylesheet" href="css/foundation.css">
    <link rel="stylesheet" href="css/app.css">
</head>
    <style>/*base*/
.error_txt{margin-bottom: 10px; display: block; color: #f00; font-size: 13px;}
.inactive{display:none;}

/*foundation-example*/
#foundation-example{}
.foundation-example__ex-wrapper{
	background-color: lightblue;
}
.foundation-example__in-wrapper{  
	margin: auto;
    max-width: 900px;
    background: white;
    padding: 30px;
}

.foundation-example__title{  
	text-align: center;
    font-size: 40px;
    margin-bottom: 32px;
}

.foundation-example__form-wrapper{  

}</style>
<body>
    <form id="form1" runat="server">
    <div>
      
      	<section id="foundation-example">
  		<div style="height: 50px;background: lightblue;"></div>
  		<div class="foundation-example__ex-wrapper">
  			<div class="foundation-example__in-wrapper">
	  			<div class="foundation-example__title"> Employee Info</div>
	  			<div class="foundation-example__form-wrapper">

          
                    		<div class="row">
							<div class="large-6 columns">
								<label>Employee No
								  <asp:TextBox ID="txtEmployeeNo"  runat="server"></asp:TextBox>
								</label>
							</div>

							<div class="large-6 columns">
								<label>Title
				          	<asp:DropDownList ID="drpTitle" runat="server" EnableViewState="False">
                                <asp:ListItem>---Select Please---</asp:ListItem>
                                <asp:ListItem>Mr</asp:ListItem>
                                <asp:ListItem>Mrs</asp:ListItem>
                                </asp:DropDownList>
							    </label>
							</div>
						</div>


						<div class="row">
							<div class="large-6 columns">
								<label>Employee Name
							  <asp:TextBox ID="txtEmployeeName"  runat="server"></asp:TextBox>
                                    </div> 
							    </label>
                            <div class="large-6 columns">
							    <label>City
							      <asp:DropDownList ID="drpCity" runat="server">
                                <asp:ListItem>---Select Please---</asp:ListItem>
                                <asp:ListItem>Dhaka</asp:ListItem>
                                <asp:ListItem>London</asp:ListItem>
                                </asp:DropDownList>
							    </label>
                                </div>
                            </div>
                    <div class="row">
                         <div class="large-6 columns">
							  <label>Phone
						  <asp:TextBox ID="txtPhone"  runat="server"></asp:TextBox>
							    </label>
							   </div>

							<div class="large-6 columns">
								<label>Address
							   <asp:TextBox ID="txtAddress" TextMode="MultiLine"   runat="server"></asp:TextBox>
							    </label>
							</div>
						</div>
                    <div class="row">
                          <div class="large-6 columns">
							  <label>DOB
						  <asp:TextBox ID="txtDateOfBirth" TextMode="Date"  runat="server"></asp:TextBox>
							    </label>
							   </div>
                         <div class="large-6 columns">
							  <label>NIC NO
						  <asp:TextBox ID="txtNIc"  runat="server"></asp:TextBox>
							    </label>
							   </div>
					</div>
                 
                      <div class="row">
                          <div class="large-6 columns">
                              <label>Gender
                            <asp:RadioButtonList ID="rbNGender" runat="server">
                                <asp:ListItem>Male</asp:ListItem>
                                <asp:ListItem>Female</asp:ListItem>
                              </asp:RadioButtonList>
                                  </Lable>
                              </div>
                         
					</div>
                    <div class="row">
                         <div class="large-6 columns">
							  <label>Photo
						<asp:FileUpload ID="FileUpload1" runat="server" />
							    </label>
							   </div>
                        </div>
						<div class="row">
						
                               <asp:Button ID="btnClear" CssClass="warning button" runat="server" Width="200px" Text="Clear" OnClick="btnClear_Click" />
							   <asp:Button ID="btnSave" CssClass="success button" Width="200px" runat="server" Text="Save" OnClick="btnSave_Click" />
                           <asp:Button ID="btnDelete" CssClass="alert button" Enabled="False" runat="server" Width="200px" Text="Delete" OnClick="btnDelete_Click" />
                             <asp:Button ID="btnReport"  CssClass="primary button" runat="server" Width="200px" Text="Report" OnClick="btnReport_Click1"  />
							</div>
                            <div style="width: 100%; height: 170px; overflow: scroll">
                    <asp:GridView ID="dgvData" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical"  OnSelectedIndexChanged="dgvData_SelectedIndexChanged" ShowHeaderWhenEmpty="True">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <Columns>
                            <asp:BoundField DataField="EmployeeNo" HeaderText="Employee No" />
                            <asp:ImageField DataImageUrlField="Photo" HeaderText="Photo">
                                <ItemStyle Height="5px" Width="2px" />
                            </asp:ImageField>
                            <asp:BoundField DataField="EmployeeName" HeaderText="EmployeeName" />
                            <asp:BoundField DataField="Phone" HeaderText="Phone" />
                            <asp:BoundField DataField="DOB" HeaderText="DOB" DataFormatString="{0:d}" />
                            <asp:BoundField DataField="NIC" HeaderText="NIC" />
                            <asp:BoundField DataField="Address" HeaderText="Address" />
                              <asp:BoundField DataField="Title" HeaderText="Title" />
                            <asp:BoundField DataField="Gender" HeaderText="Gender" />
                            <asp:BoundField DataField="City" HeaderText="City" />
                              <asp:TemplateField HeaderText="Action" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Edit"></asp:LinkButton>
                                </ItemTemplate>

                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="Gray" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                                </asp:GridView>
        
         
               
                 
         
               
           
         
               
                 
         
               
   

				
						
					
	  			</div>
  			</div>
  		</div>
  		<div style="height: 50px;background: lightblue;"></div>
  	</section>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="js/vendor/jquery.js"></script>
    <script src="js/vendor/what-input.js"></script>
    <script src="js/vendor/foundation.js"></script>
    <script src="js/app.js"></script>
    </div>
    </form>
</body>
        <link href="//cdnjs.cloudflare.com/ajax/libs/foundation/6.3.1/css/foundation.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//cdnjs.cloudflare.com/ajax/libs/foundation/6.3.1/js/foundation.min.js"></script>
<script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
</html>
