<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddReview.aspx.cs" Inherits="RishIyerProject3.AddReview" %>

<!DOCTYPE html>
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css"/>
<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
<link href="https://fonts.googleapis.com/css2?family=IBM+Plex+Sans:wght@300&display=swap" rel="stylesheet"/>
<link rel="stylesheet" type="text/css" href="Style.css" />
    <link rel="stylesheet" type="text/css" href="styleAll.css" />

    <script>
     
    </script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      <asp:Panel ID="panelNavRep" runat="server">
            <div class="navRep" runat="server">
                <ul>
                     <li>
  <a href="Dashboard.aspx">
                   All Restaurants
                </a>
                   </li>
                <li><a href="AddRest.aspx">
                    Add Restaraunt
                    </a>
                </li>
                    <li>
                <a href="MyRests.aspx">
                    My Restaraunts
                </a>
                        </li>
                    <li>
                <a href="MakeReservation.aspx">
                    Make Reservation
                </a>
                        </li>
                    <li>
                <a href="ManageReservations.aspx">
                    Manage Reservations
                </a>
                        </li>
                    <li class="float-right">
                        <asp:Label ID="lblLoggedInAs" runat="server" Text=""></asp:Label>
                    </li>
                    <li>
                        <a href="Home.aspx"> Log Off</a>
                    </li>
               </ul>
            </div>
                 </asp:Panel>
           <asp:Panel ID="panelNavReviewer" runat="server">
            <div class="navRep" runat="server">
                <ul>
                     <li>
  <a href="Dashboard.aspx">
                   All Restaurants
                </a>
                   </li>
                <li><a href="AddRest.aspx">
                    Add Restaraunt
                    </a>
                </li>
                    <li>
                <a href="MyReviews.aspx">
                    My Reviews
                </a>
                        </li>
                    <li>
                <a href="MakeReservation.aspx">
                    Make Reservation
                </a>
                        </li>
                    <li>
                <a href="AddReview.aspx">
                  Add Review
                </a>
                        </li>
                    <li class="float-right">
                        <asp:Label ID="lblSignedInAsReviewer" runat="server" Text=""></asp:Label>
                    </li>
                    <li>
                        <a href="Home.aspx"> Log Off</a>
                    </li>
               </ul>
            </div>
               </asp:Panel>
            <asp:Panel ID="panelGuest" runat="server">

     
             <div class="navGuest" runat="server">
               <ul>
                   <li>
  <a href="Dashboard.aspx">
                   All Restaurants
                </a>
                   </li>
                   <li>
  <a href="MakeReservation.aspx">
                    Make Reservation
                </a>
                   </li>
                   <li class="float-right">
<a href="Home.aspx"> Sign Up</a>
                   </li>
               </ul>
               
                
               </div>

                       </asp:Panel>
   <asp:Label ID="lblTitle" runat="server" Text="Add Review" CssClass="lblTitle"></asp:Label>

        
        <br /> 
       <div class="formContainer2">


             <asp:Label ID="lblNameError" runat="server" Text="" CssClass="errorReservation"></asp:Label> <br /> 
                <asp:Label ID="lblDescriptionError" runat="server" Text="" CssClass="errorReservation"></asp:Label><br />
                      <asp:Label ID="lblPhoneError" runat="server" Text=""  CssClass="errorReservation"></asp:Label><br />
                       <asp:Label ID="lblImgError" runat="server" Text=""  CssClass="errorReservation"></asp:Label><br />
                 <asp:Label ID="lblTypeError" runat="server" Text="" CssClass="errorReservation" ></asp:Label><br />
              <asp:Label ID="lblAddressError" runat="server" Text="" CssClass="errorReservation" ></asp:Label><br />

               <asp:Button ID="btnReviewExist" runat="server" Text="Review Existing Restaurant " OnClick="btnReviewExist_Click" class="btn btn-outline-dark btn-lg btn-block" Width="290px" />
        <asp:Button ID="btnAddNewRest" runat="server" Text="Add A New Restaraunt " OnClick="btnAddNewRest_Click" class="btn btn-outline-dark btn-lg btn-block" Width="250px" /><br /><br />
         <asp:Panel ID="panelAddNewRest" runat="server">
        <asp:Label ID="lblRestName" runat="server" Text="Restaraunt Name" CssClass="labelForm"></asp:Label>
        <asp:TextBox ID="txtRestName" runat="server"  CssClass="textboxForm"></asp:TextBox><br /><br />
            <asp:Label ID="lblRestPhone" runat="server" Text="Phone Number" CssClass="labelForm"></asp:Label>
        <asp:TextBox ID="txtRestPhone" runat="server"  CssClass="textboxForm"></asp:TextBox><br /><br />
           <asp:Label ID="lblRestAddress" runat="server" Text=" Address" CssClass="labelForm"></asp:Label>
        <asp:TextBox ID="txtRestAddress" runat="server"  CssClass="textboxForm"></asp:TextBox><br /><br />
                <asp:Label ID="lblRestType" runat="server" Text="Category" CssClass="labelForm"></asp:Label>
        <asp:TextBox ID="txtRestType" runat="server"  CssClass="textboxForm"></asp:TextBox><br /><br />
            <asp:Label ID="lblRestDescription" runat="server" Text="Description" CssClass="labelForm"></asp:Label>
        <asp:TextBox ID="txtRestDescription" runat="server"  CssClass="textboxForm"></asp:TextBox><br /><br />
                <asp:Label ID="lblRestImgURL" runat="server" Text="Image URL" CssClass="labelForm"></asp:Label>
        <asp:TextBox ID="txtRestImgURL" runat="server"  CssClass="textboxForm"></asp:TextBox><br /><br />

        <asp:Button ID="btnAddRest" runat="server" Text="Add Restaraunt" OnClick="btnAddRest_Click" class="btn btn-outline-dark btn-lg btn-block" Width="250px"  />
            </asp:Panel>
        <br /><br />
          <asp:Panel ID="panelAddNewReview" runat="server">
              
             <asp:Label ID="lblServiceError" runat="server" Text="" CssClass="errorReservation"></asp:Label> <br /> 
                <asp:Label ID="lblQualityError" runat="server" Text="" CssClass="errorReservation"></asp:Label><br />
                      <asp:Label ID="lblCommentsError" runat="server" Text=""  CssClass="errorReservation"></asp:Label><br />
                       <asp:Label ID="lblPriceError" runat="server" Text=""  CssClass="errorReservation"></asp:Label><br />
                 <asp:Label ID="lblAtmosphereError" runat="server" Text="" CssClass="errorReservation" ></asp:Label><br />
            
           <asp:Label ID="lblSelectRest" runat="server" Text="Select A Restaraunt" CssClass="labelForm"></asp:Label>
        <asp:DropDownList ID="ddlRests" runat="server"  CssClass="textboxForm"></asp:DropDownList> <br /><br />
           <asp:Label ID="lblComments" runat="server" Text="Write your review:" CssClass="labelForm"></asp:Label>
        <asp:TextBox ID="txtComments" runat="server"  CssClass="textboxForm"></asp:TextBox>
        <br /><br />
     
          <asp:Label ID="lblRateQuality" runat="server" Text="Rate Food Quality(1-5)" CssClass="labelForm"></asp:Label> 
       <asp:DropDownList ID="ddlRateQuality" runat="server" CssClass="yellow textboxForm">
           <asp:ListItem Value="1"> ★ </asp:ListItem>
              <asp:ListItem Value="2"> ★★ </asp:ListItem>
              <asp:ListItem Value="3"> ★★★ </asp:ListItem>
              <asp:ListItem Value="4"> ★★★★ </asp:ListItem>
              <asp:ListItem Value="5"> ★★★★★ </asp:ListItem>
       </asp:DropDownList>

              <br /><br />
          <asp:Label ID="lblRateAtmosphere" runat="server" Text="Rate Atmosphere(1-5)" CssClass="labelForm"></asp:Label> 
     <asp:DropDownList ID="ddlRateAtmosphere" runat="server" CssClass="yellow textboxForm">
           <asp:ListItem Value="1"> ★ </asp:ListItem>
              <asp:ListItem Value="2"> ★★ </asp:ListItem>
              <asp:ListItem Value="3"> ★★★ </asp:ListItem>
              <asp:ListItem Value="4"> ★★★★ </asp:ListItem>
              <asp:ListItem Value="5"> ★★★★★ </asp:ListItem>
       </asp:DropDownList>
              <br /><br />



           <asp:Label ID="lblRateService" runat="server" Text="Rate Service(1-5)" CssClass="labelForm"></asp:Label> 
         <asp:DropDownList ID="ddlRateService" runat="server" CssClass="yellow textboxForm">
           <asp:ListItem Value="1"> ★ </asp:ListItem>
              <asp:ListItem Value="2"> ★★ </asp:ListItem>
              <asp:ListItem Value="3"> ★★★ </asp:ListItem>
              <asp:ListItem Value="4"> ★★★★ </asp:ListItem>
              <asp:ListItem Value="5"> ★★★★★ </asp:ListItem>
       </asp:DropDownList>
              <br /><br />
          <asp:Label ID="lblRatePrice" runat="server" Text="Rate Price(1-5)"  CssClass="labelForm"></asp:Label> 
         <asp:DropDownList ID="ddlRatePrice" runat="server" CssClass="green textboxForm">
           <asp:ListItem Value="1"> $ </asp:ListItem>
              <asp:ListItem Value="2"> $$ </asp:ListItem>
              <asp:ListItem Value="3"> $$$ </asp:ListItem>
              <asp:ListItem Value="4"> $$$$ </asp:ListItem>
              <asp:ListItem Value="5"> $$$$$ </asp:ListItem>
       </asp:DropDownList>
              <br /><br />
            <asp:Button ID="btnSubmitReview" runat="server" Text="Submit Review" OnClick="btnSubmitReview_Click" class="btn btn-outline-dark btn-lg btn-block" Width="250px"/>
              <asp:Label ID="lblSuccess" runat="server"></asp:Label>
              </asp:Panel>
           </div>
    </form>

</body>
</html>
