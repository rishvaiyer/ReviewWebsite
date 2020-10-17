<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="RishIyerProject3.Home" %>

<!DOCTYPE html>
<html>
    <head runat="server">
    <meta charset="utf-8" />
        <link href="https://fonts.googleapis.com/css2?family=Pacifico&display=swap" rel="stylesheet">
        <link href="https://fonts.googleapis.com/css2?family=Secular+One&display=swap" rel="stylesheet">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
<link href="https://fonts.googleapis.com/css2?family=IBM+Plex+Sans:wght@300&display=swap" rel="stylesheet">
<link rel="stylesheet" type="text/css" href="StyleHomePage.css" />
        <link rel="stylesheet" type="text/css" href="styleAll.css" />
        <script>

        </script>

    <title></title>
</head>


<body>

    
    
         
       <div id="title"> Dine or Dash</div> 
     <img id="imageHome" src="pics/Dining.jpg" />
          <div class="continueAs"> The restaurant review site with the facts.</div>
  
        
              
    <br /><br /><br />


    <form id="form1" runat="server">


        <div>

        <div class="LogIn">
 
       <div class="subTitle"><asp:Label ID="subTitle" runat="server">Continue as a...</asp:Label> </div> 
                 <div class="subTitle"><asp:Label ID="lblSignUp" runat="server" CssClass="labelWhite">New User Sign Up</asp:Label> </div> 
                <div class="subTitle"><asp:Label ID="lblLogInRep" runat="server" CssClass="labelWhite">Log In As Representative</asp:Label> </div> 
              <div class="subTitle"><asp:Label ID="lblLogInReviewer" runat="server" CssClass="labelWhite">Log In As Reviewer</asp:Label> </div>
             <div class="subTitle"><asp:Label ID="lblSuccessCreation" runat="server" CssClass="labelWhite">Your account has successfully been created. You can login <a href="Home.aspx"> here</a></asp:Label> </div>
            <br /><br /><br />
             <div class="d-flex justify-content-center">
;<asp:Button ID="btnRep" class="btn btn-light btn-lg btn-block" runat="server" Text="Restarunt Representitive" Width="490px" OnClick="btnRep_Click" />
            <br />
                 </div>
            <div class="d-flex justify-content-center">
                     <asp:Button ID="btnReview" class="btn btn-light btn-lg btn-block" runat="server" Text="Reviewer" Width="490px" OnClick="btnReview_Click" />
            <br /></div>
            <div class="d-flex justify-content-center">
      <asp:Button ID="btnGuest" class="btn btn-light btn-lg btn-block" runat="server" Text="Guest" OnClick="btnGuest_Click" Width="490px" /> 
          
                </div>
                <asp:Label ID="lblDisplayError" runat="server" Text="" ForeColor="Red"></asp:Label>
                 <div class="d-flex justify-content-center">
            <asp:Button ID="btnCreateNewAccount" runat="server" class="btn btn-light btn-lg btn-block" Text="Sign Up" OnClick="btnCreateNewAccount_Click" Width="200px" />
                     </div>
                      <asp:Panel ID="panelSignUp" runat="server" HorizontalAlign="Center">
    <asp:Label ID="lblErrorUsername" runat="server" Text="" ForeColor="Red"></asp:Label><br />
           <asp:Label ID="lblErrorFirstName" runat="server" Text="" ForeColor="Red" ></asp:Label><br /> 
                <asp:Label ID="lblErrorLastName" runat="server" Text="" ForeColor="Red"></asp:Label><br />
            <asp:Label ID="lblType" runat="server" Text="Type of Account" CssClass="labelFormHome"></asp:Label>
           <asp:DropDownList ID="ddlSignUpType" runat="server" CssClass="textboxForm">
               <asp:ListItem Value="Reviewers"> Reviewer </asp:ListItem> 
               <asp:ListItem Value="Reps"> Representative</asp:ListItem>
           </asp:DropDownList><br /><br />
           <asp:Label ID="lblUsernameSignUp" runat="server" Text="Username" CssClass="labelFormHome"></asp:Label>
           <asp:TextBox ID="txtUsernameSignUp" runat="server" CssClass="textboxForm"></asp:TextBox> <br /><br />
                <asp:Label ID="lblFirstName" runat="server" Text="First Name" CssClass="labelFormHome"></asp:Label>
           <asp:TextBox ID="txtFirstNameSignUp" runat="server" CssClass="textboxForm"></asp:TextBox><br /><br />
                <asp:Label ID="lblLastName" runat="server" Text="Last Name" CssClass="labelFormHome"></asp:Label>
           <asp:TextBox ID="txtLastNameSignUp" runat="server" CssClass="textboxForm"></asp:TextBox><br /><br />
            
                     <asp:Button ID="btnBackSignUp" runat="server" Text="Back" class="btn btn-light btn-lg btn-block float-left" Width="100px" OnClick="btnBackSignUp_Click"   />
           <asp:Button ID="btnSignUp" runat="server" Text="Create Account" class="btn btn-light btn-lg btn-block float-right"  Width="160px" OnClick="btnSignUp_Click"   />
                  
        
     
          
         </asp:Panel>

              
            <asp:Panel ID="panelReviewerLookup" runat="server">
                <asp:Label ID="lblErrorReviewer" runat="server" Text=""  ForeColor="Red" CssClass="labelErrorHome"></asp:Label>
            <asp:Label ID="lblReviewerLookup" runat="server" Text="Please enter your User ID:" CssClass="labelFormHome"></asp:Label>
                <asp:TextBox ID="txtReviewerLookup" runat="server" CssClass="textboxForm"></asp:TextBox><br /><br /><br />
                <asp:Button ID="btnReviewerLookup" runat="server" Text="Go" class="btn btn-light btn-lg btn-block float-right align-bottom "  Width="100px" OnClick="btnReviewerLookup_Click" />
                  <asp:Button ID="btnBackReviewer" runat="server" Text="Back" class="btn btn-light btn-lg btn-block float-left align-bottom" Width="100px" OnClick="btnBackReviewer_Click"  />
            </asp:Panel>


            <asp:Panel ID="panelRepLookup" runat="server">
                   <asp:Label ID="lblErrorRep" runat="server" Text=""  ForeColor="Red"  CssClass="labelErrorHome"></asp:Label>
              <asp:Label ID="lblRepLookup" runat="server" Text="Please enter your User ID:" CssClass="labelFormHome"></asp:Label>
                <asp:TextBox ID="txtRepLookup" runat="server" CssClass="textboxForm"> </asp:TextBox><br /><br /><br />
                <asp:Button ID="btnRepLookup" runat="server" Text="Go" class="btn btn-light btn-lg btn-block float-right align-bottom" Width="100px" OnClick="btnRepLookup_Click"  />
                  
                
                   <asp:Button ID="btnBackRep" runat="server" Text="Back" class="btn btn-light btn-lg btn-block float-left align-bottom " Width="100px" OnClick="btnBackRep_Click"  />
            </asp:Panel>
        
          

            </div>


        </div>
     
       
    </form>
       
</body>
</html>
