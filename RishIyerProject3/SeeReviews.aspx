<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeeReviews.aspx.cs" Inherits="RishIyerProject3.SeeReviews" %>

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
    <meta charset="utf-8" />
 
    
    
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


            <asp:Label ID="lblTitle" runat="server" Text="Reviews" CssClass="lblTitle"></asp:Label>
              <div class="gvContainer">

                  <asp:Image ID="imgPickedRest" runat="server" />
                  <asp:Panel ID="panelRatings" runat="server" CssClass="float-left">
                      <asp:Label ID="lblAvgFoodQuality" runat="server" Text="" CssClass=" averageRatings"></asp:Label><br />
                       <asp:Label ID="lbLAvgService" runat="server" Text="" CssClass="averageRatings"></asp:Label><br />
                       <asp:Label ID="lblAvgAtmosphere" runat="server" Text="" CssClass=" averageRatings"></asp:Label><br /><br />
                       
                       <asp:Label ID="lblOverallRating" runat="server" Text="" CssClass=" finalRating"></asp:Label><br />
                       <asp:Label ID="lblAvgPrice" runat="server" Text="" CssClass=" finalRating"></asp:Label><br />
                  </asp:Panel>
                  <br /><br /><br />

            <asp:gridview runat="server" ID="gvSpecificReviews" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="994px" AutoGenerateColumns="False" >
                <Columns>
              
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Username" HeaderText="Reviewer" SortExpression="Username" />
                    <asp:BoundField DataField="FoodQuality" HeaderText="Food Quality Rating" SortExpression="FoodQuality" />
                    <asp:BoundField DataField="Service" HeaderText="Service Rating" SortExpression="Service" />
                    <asp:BoundField DataField="Atmosphere" HeaderText="Atmosphere Rating" SortExpression="Atmosphere" />
                    <asp:BoundField DataField="Price" HeaderText="Price Rating" SortExpression="Price" />
                    <asp:BoundField DataField="AvgRating" HeaderText="Average Rating" SortExpression="AvgRating" />
                    <asp:BoundField DataField="Comments" HeaderText="Review" SortExpression="Comments" />
                </Columns>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:gridview>
                              <asp:Label ID="lblNoReviews" runat="server" Text=""  CssClass="displayNoneText"></asp:Label><br />
                    <asp:Button ID="btnBack" runat="server" Text="Back" class="btn btn-outline-dark btn-sm btn-block float-left" Width="100px" OnClick="btnBack_Click"   />

           </div>
            </div>
    </form>
</body>

</html>
