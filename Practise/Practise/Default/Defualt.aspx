<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Defualt.aspx.cs" Inherits="Practise.Default.Defualt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <link rel="stylesheet" href="css/app.css">
    <style>.error_txt{margin-bottom: 10px; display: block; color: #f00; font-size: 13px;}
.inactive{display:none;}

/*foundation-example*/
#foundation-example{}
.foundation-example__ex-wrapper{
	background-color: lightblue;
}
.foundation-example__in-wrapper{  
	margin: auto;
    max-width: 700px;
    background: white;
    padding: 30px;
}

.foundation-example__title{  
	text-align: center;
    font-size: 40px;
    margin-bottom: 32px;
}

.foundation-example__form-wrapper{  

}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <section id="foundation-example">
  		<div style="height: 30px;background: lightblue;"></div>
  		<div class="foundation-example__ex-wrapper">
  			<div class="foundation-example__in-wrapper">
	  			<div class="foundation-example__title"> Catagory</div>
	  			<div class="foundation-example__form-wrapper">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <ContentTemplate>

                      <div class="row">
                          
			<div class="large-4 columns">

       <asp:TextBox ID="TextBox1" PlaceHolder="Search Id..."  runat="server"></asp:TextBox>
              
          </div>    
  <asp:Button ID="Button1" class="success button" Width="100px" runat="server" Text="Serach" />
  

						</div>
                      <div class ="row">
                          <div class="large-6 columns">
     <asp:TextBox ID="txtDate" TextMode="Date"  runat="server"></asp:TextBox>
</div>
                      </div>
                    <div class="row">
                        <div class="large-6 columns">
                            <label>Employee
                            <asp:DropDownList ID="drpEmployee" AutoPostBack="true" runat="server" OnSelectedIndexChanged="drpEmployee_SelectedIndexChanged"></asp:DropDownList>
                              </label>
                        </div>
                          <div class="large-6 columns">
                            <label>Department
                         <asp:TextBox ID="txtDepartmnet" runat="server"></asp:TextBox>
                              </label>
                        </div>
                    </div>

                      <div class="row">
                           <div class="large-6 columns">
                          Covid Affected?
                        <asp:RadioButtonList ID="rbn" runat="server">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                          </asp:RadioButtonList>
                               </div>
                        <div class="large-6 columns">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </div>
                      </div>
                      <div class="row">
                             <div class="large-6 columns">Lives Outside Of Dhaka<br>
                               <asp:CheckBox ID="Yeschk" Text="Yes" runat="server" AutoPostBack="true" OnCheckedChanged="Yeschk_CheckedChanged" />
                                <asp:CheckBox ID="Nochk" Text="No" runat="server" AutoPostBack="true" OnCheckedChanged="Nochk_CheckedChanged" />
                           </div>
                      </div>
						<div class="row" >
                          <div class="large-8 columns">  
  
							
					    <asp:Button ID="btnSave" class="success button" runat="server" Text="Save"  Font-Size="Medium" Width="180px" OnClick="btnSave_Click" />
                        <asp:Button ID="btnReport" runat="server" Text="Report" class="button alert" Font-Size="Medium" Width="180px" OnClick="btnReport_Click"  />
                            
                               </div>
	 
                               
						</div>
           
         <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
                               <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
                      <div style="width: 100%; height: 400px; overflow: scroll">
                  
    </div>
         		   </ContentTemplate>
     <Triggers>
          <asp:PostBackTrigger ControlID="btnSave" />
 </Triggers>
          </asp:UpdatePanel>
    </form>
         <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="js/vendor/jquery.js"></script>
    <script src="js/vendor/what-input.js"></script>
    <script src="js/vendor/foundation.js"></script>
    <script src="js/app.js"></script>
</body>


  
    <link href="//cdnjs.cloudflare.com/ajax/libs/foundation/6.3.1/css/foundation.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//cdnjs.cloudflare.com/ajax/libs/foundation/6.3.1/js/foundation.min.js"></script>
<script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
</html>
