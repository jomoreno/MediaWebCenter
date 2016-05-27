<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MediaWebCenter.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="../scripts/jquery-1.12.4.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="summariesContainer" >
        <div class="summaryContainer">
            <div class="hover"> <asp:Label ID="Label1" runat="server" Text="Movies"></asp:Label> </div>
            <a href="#"><img alt="" runat="server" id="imageMovies" src="../images/sucker_punch_movie-t2.jpg"/></a> 
        </div>
        <div class="summaryContainer" >
            <div class="hover"> <asp:Label ID="Label2" runat="server" Text="TV Series"></asp:Label> </div>
            <a href="#"><img alt="" runat="server" id="imageTV" src="../images/Bones.jpg"  /></a> 
        </div>
        <div class="summaryContainer" >
            <div class="hover"> <asp:Label ID="Label3" runat="server" Text="Anime Series"></asp:Label> </div>
            <a href="#"><img alt="" runat="server" id="imageAnime" src="../images/eva.jpg"  /> </a>
        </div>
        <div class="summaryContainer" >
            <div class="hover"> <asp:Label ID="Label4" runat="server" Text="Games"></asp:Label> </div>
            <a href="#"><img alt="" runat="server" id="imageGames" src="../images/crysis-2Reduced.jpg"  /></a>
        </div>
    </div>

    <div id="dvLoading">
        <img id="loading-image" class="loadingImage" src="images/loadingProcessing.gif" alt="Loading..." />
    </div>

    <script lang="javascript" type="text/javascript">
        
        $(".summaryContainer").hover(function () {
            $(this).children("a").fadeTo(200, 0.20).end().children(".hover").show(); 
        }, function () {
            $(this).children("a").fadeTo(200, 1).end().children(".hover").hide();
        });

        $(window).load(function () {
            $('#dvLoading').fadeOut(1000);
        });


    </script>
</asp:Content>
