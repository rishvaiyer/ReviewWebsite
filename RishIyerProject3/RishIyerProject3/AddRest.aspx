<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRest.aspx.cs" Inherits="RishIyerProject3.AddRest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <link href="https://fonts.googleapis.com/css2?family=Secular+One&display=swap" rel="stylesheet"/>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css"/>
<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
<link href="https://fonts.googleapis.com/css2?family=IBM+Plex+Sans:wght@300&display=swap" rel="stylesheet"/>
    <link rel="stylesheet" type="text/css" href="StyleAll.css" />
    <title></title>

    <style type="text/css">
        .textboxForm {
            color: #FF0000;
        }
        .labelForm {
            font-weight: bold;
        }
    </style>

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
         
              <asp:Label ID="lblTitle" runat="server" Text="Add New Restaurant" CssClass="lblTitle"></asp:Label>
         <div class="formContainer2">

                 <asp:Label ID="lblNameError" runat="server" Text="" CssClass="errorReservation"></asp:Label><br />
               <asp:Label ID="lblPhoneError" runat="server" Text="" CssClass="errorReservation" ></asp:Label><br />
             
               <asp:Label ID="lblAddressError" runat="server" Text="" CssClass="errorReservation"  ></asp:Label><br />
               <asp:Label ID="lblTypeError" runat="server" Text="" CssClass="errorReservation"  ></asp:Label><br />
               <asp:Label ID="lblDescriptionError" runat="server" Text="" CssClass="errorReservation"  ></asp:Label><br />
               <asp:Label ID="lblImgError" runat="server" Text="" CssClass="errorReservation" ></asp:Label><br />
               <asp:Label ID="lblUsernameError" runat="server" Text="" CssClass="errorReservation"  ></asp:Label>

           <asp:Panel ID="panelNewRest" runat="server">
     
               <br />
            <asp:Label ID="lblRestName" runat="server" Text="Restaraunt Name" CssClass="labelForm"></asp:Label>
        <asp:TextBox ID="txtRestName" runat="server"  CssClass="textboxForm" ForeColor="Black" ></asp:TextBox>
            <br /><br />
            <asp:Label ID="lblRestPhone" runat="server" Text="Phone Number" CssClass="labelForm"></asp:Label>
        <asp:TextBox ID="txtRestPhone" runat="server"  CssClass="textboxForm" ForeColor="Black" ></asp:TextBox>
         <br /><br />
           <asp:Label ID="lblRestAddress" runat="server" Text=" Address" CssClass="labelForm"></asp:Label>
        <asp:TextBox ID="txtRestAddress" runat="server"  CssClass="textboxForm" ForeColor="Black"></asp:TextBox>
            <br /><br />
                <asp:Label ID="lblRestType" runat="server" Text="Category" CssClass="labelForm"></asp:Label>
        <asp:TextBox ID="txtRestType" runat="server"  CssClass="textboxForm" ForeColor="Black" ></asp:TextBox>
          <br /><br />
            <asp:Label ID="lblRestDescription" runat="server" Text="Description" CssClass="labelForm"></asp:Label>
        <asp:TextBox ID="txtRestDescription" runat="server"  CssClass="textboxForm" ForeColor="Black"></asp:TextBox>
       <br /><br />
             <asp:Label ID="lblRestImgURL" runat="server" Text="Image URL" CssClass="labelForm"></asp:Label>
        <asp:TextBox ID="txtRestImgURL" runat="server"  CssClass="textboxForm" ForeColor="Black" ></asp:TextBox>
            <br />
               <br />
               <asp:Label ID="lblRepUsername" runat="server" Text="Rep Username" CssClass="labelForm"></asp:Label>
        <asp:TextBox ID="txtRepUsername" runat="server" CssClass="textboxForm" ForeColor="Black" ></asp:TextBox> 
            <br /><br />
                       <asp:Button ID="btnAddRest" runat="server" Text="Add Restaraunt" OnClick="btnAddRest_Click" class="btn btn-outline-dark btn-lg btn-block" Width="200px" />


                <asp:Label ID="lblSuccess" runat="server" Text="Your restaraunt has been successfully added."></asp:Label>
                     </asp:Panel>
                </div>
                </div>
      </div>

       
        
    </form>

</body>
</html>
