<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MakeReservation.aspx.cs" Inherits="RishIyerProject3.MakeReservation" %>

<!DOCTYPE html>
 <link href="https://fonts.googleapis.com/css2?family=Secular+One&display=swap" rel="stylesheet">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
<link href="https://fonts.googleapis.com/css2?family=IBM+Plex+Sans:wght@300&display=swap" rel="stylesheet">
   <link rel="stylesheet" type="text/css" href="StyleAll.css" />
<html xmlns="http://www.w3.org/1999/xhtml">
  
<head runat="server">
      
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

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


             <asp:Label ID="lblTitle" runat="server" Text="Make Reservation" CssClass="lblTitle"></asp:Label>
            <br /><br />

              
  
             <div class="formContainer2">
     
                
          <asp:Label ID="lblFirstNameError" runat="server" Text="" CssClass="errorReservation"></asp:Label> <br /> 
                <asp:Label ID="lblLastNameError" runat="server" Text="" CssClass="errorReservation"></asp:Label><br />
                      <asp:Label ID="lblPhoneError" runat="server" Text=""  CssClass="errorReservation"></asp:Label><br />
                       <asp:Label ID="lblDateError" runat="server" Text=""  CssClass="errorReservation"></asp:Label><br />
                 <asp:Label ID="lblTimeError" runat="server" Text="" CssClass="errorReservation" ></asp:Label><br />

                 
              <asp:label ID="lblRestName" runat="server" text="Select Restaurant" CssClass="labelForm"></asp:label>
            <asp:DropDownList ID="ddlRests" runat="server" CssClass="textboxForm"></asp:DropDownList> <br /><br />
            <asp:label ID="lblFirstName" runat="server" text="First Name" CssClass="labelForm"></asp:label>
        <asp:TextBox ID="txtFirstName" runat="server" CssClass="textboxForm"></asp:TextBox><br /><br />
            <asp:label ID="lblLastName" runat="server" text="Last Name" CssClass="labelForm"></asp:label>
            <asp:TextBox ID="txtLastName" runat="server" CssClass="textboxForm"></asp:TextBox><br /><br />
            <asp:label ID="lblPhoneNumber" runat="server" text="Phone Number" CssClass="labelForm"></asp:label>
             <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="textboxForm"></asp:TextBox><br /><br />
            <asp:label ID="lblDate" runat="server" text="Date" CssClass="labelForm"></asp:label>
             <asp:TextBox ID="txtDate" runat="server" TextMode="Date" CssClass="textboxForm"></asp:TextBox><br /><br />
             <asp:label ID="lblTime" runat="server" text="Time" CssClass="labelForm"></asp:label>
             <asp:TextBox ID="txtTime" runat="server" TextMode="Time" CssClass="textboxForm"></asp:TextBox><br /><br />
            <asp:Button ID="btnSubmitReservation" runat="server" Text="Submit Reservation" OnClick="btnSubmitReservation_Click" class="btn btn-outline-dark btn-lg btn-block" Width="250px" />

                <asp:label ID="lblDisplay" runat="server" text=""></asp:label>
        </div>
       </div>
    </form>
</body>

</html>

