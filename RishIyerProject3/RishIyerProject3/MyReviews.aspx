<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyReviews.aspx.cs" Inherits="RishIyerProject3.MyReviews" %>
    
<!DOCTYPE html>
<link href="https://fonts.googleapis.com/css2?family=Secular+One&display=swap" rel="stylesheet">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
<link href="https://fonts.googleapis.com/css2?family=IBM+Plex+Sans:wght@300&display=swap" rel="stylesheet">
   <link rel="stylesheet" type="text/css" href="StyleAll.css" />
<html>
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
            <asp:Label ID="lblTitle" runat="server" Text="My Reviews" CssClass="lblTitle"></asp:Label>
       <div class="gvContainer">
            <asp:GridView ID="gvMyReviews" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnRowCommand="gvMyReviews_RowCommand" AutoGenerateColumns="False" EnableViewState="False" OnRowEditing="gvMyReviews_RowEditing" OnRowUpdating="gvMyReviews_RowUpdating" OnSelectedIndexChanged="gvMyReviews_SelectedIndexChanged" OnRowCancelingEdit="gvMyReviews_RowCancelingEdit" Width="1136px">
                <Columns>
                   <asp:BoundField DataField="ReviewID" HeaderText="ID" Visible="false" ReadOnly="true" />
                    <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Delete" ShowHeader="True" Text="Delete" ControlStyle-CssClass="btn btn-outline-dark"  />        
                    <asp:BoundField DataField="Name" HeaderText="Restaraunt " SortExpression="Name" readonly="true"/>
                    <asp:BoundField DataField="FoodQuality" HeaderText="Food Quality " SortExpression="FoodQuality" />
                    <asp:BoundField DataField="Service" HeaderText="Service" SortExpression="Service" />
                    <asp:BoundField DataField="Atmosphere" HeaderText="Atmosphere" SortExpression="Atmosphere" />
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                    <asp:BoundField DataField="Comments" HeaderText="Comments" SortExpression="Comments" />
                  <asp:BoundField DataField="AvgRating" HeaderText="Average Rating" SortExpression="AvgRating" ReadOnly="true" />
                    <asp:CommandField ButtonType="Button" HeaderText="Edit Review" ShowEditButton="True" ShowHeader="True" ControlStyle-CssClass="btn btn-outline-dark"  />
                 
                </Columns>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>
            <asp:Label ID="lblShowIndex" runat="server" Text=""></asp:Label>
           </div>
        </div>
    </form>
</body>
</html>
