<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeBehind="MultimediaSelection.aspx.cs" Inherits="MediaWebCenter.MultimediaSelection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../scripts/jquery-1.12.4.min.js"></script>
    <script src="scripts/jquery.nanoscroller.min.js"></script>
    <link href="styles/nanoscroller.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script runat="server">

        protected String GetTimeTricks()
        {
            return DateTime.Now.Ticks.ToString();
        }

    </script>

<%--      <div id="Clickable">
            Click Here
      </div>--%>

    <div id="container">
        <div class="divSelection">
            <div class="divSelectionContainer">
                    <label class="label">Media Type : </label>
                    <asp:RadioButtonList ID="mediaSelection" ClientIDMode="Static" CssClass="radio" RepeatDirection="Horizontal" runat="server">
                        <asp:ListItem Selected="True">Movies</asp:ListItem>
                        <asp:ListItem>TV Series</asp:ListItem>
                        <asp:ListItem>Anime Series</asp:ListItem>
                        <asp:ListItem>Games</asp:ListItem>
                    </asp:RadioButtonList>
            </div>
            <div class="divSelectionContainer">
                    <label class="label">Display Mode : </label>
                    <asp:RadioButtonList ID="displayMode" CssClass="radio" ClientIDMode="Static" AutoPostBack="true" OnSelectedIndexChanged="displayMode_SelectedIndexChanged" RepeatDirection="Horizontal" runat="server">
                        <asp:ListItem Selected="True">Image Grid</asp:ListItem>
                        <asp:ListItem>List</asp:ListItem>
                        <asp:ListItem>Details</asp:ListItem>
                    </asp:RadioButtonList>
            </div>
            <div class="divInnerContainerButton"> 
                <asp:ImageButton ID="filterSearch" ImageUrl="~/images/search.png" CssClass="filterButton" runat="server" OnClick="filterSearch_Click" />
            </div>
         </div>

        <div class="divSearch">
            <div class="divSearchContainer">
                 <label class="label">Filter By Letter: </label>
                 <asp:DropDownList ID="ddlLetter" CssClass="dropdownSearch" runat="server">
                     <asp:ListItem Selected="True">#</asp:ListItem>
                     <asp:ListItem>A</asp:ListItem>
                     <asp:ListItem>B</asp:ListItem>
                     <asp:ListItem>C</asp:ListItem>
                     <asp:ListItem>D</asp:ListItem>
                     <asp:ListItem>E</asp:ListItem>
                     <asp:ListItem>F</asp:ListItem>
                     <asp:ListItem>G</asp:ListItem>
                     <asp:ListItem>H</asp:ListItem>
                     <asp:ListItem>I</asp:ListItem>
                     <asp:ListItem>J</asp:ListItem>
                     <asp:ListItem>K</asp:ListItem>
                     <asp:ListItem>M</asp:ListItem>
                     <asp:ListItem>N</asp:ListItem>
                     <asp:ListItem>O</asp:ListItem>
                     <asp:ListItem>P</asp:ListItem>
                     <asp:ListItem>Q</asp:ListItem>
                     <asp:ListItem>R</asp:ListItem>
                     <asp:ListItem>S</asp:ListItem>
                     <asp:ListItem>T</asp:ListItem>
                     <asp:ListItem>U</asp:ListItem>
                     <asp:ListItem>V</asp:ListItem>
                     <asp:ListItem>W</asp:ListItem>
                     <asp:ListItem>X</asp:ListItem>
                     <asp:ListItem>Y</asp:ListItem>
                     <asp:ListItem>Z</asp:ListItem>
                 </asp:DropDownList>
            </div>
            <div class="divSearchContainer">
                <label class="label">Search by Name: </label>
                <asp:TextBox ID="txt_SearchValue" ClientIDMode="Static" CssClass="textboxSearch" runat="server"></asp:TextBox>
            </div>
        </div>
        
        <div class="divContent">
            <div id="divContentHeader">
                <asp:Label ID="lbl_ContentTitle" runat="server" CssClass="labelResult" Text="Showing Movies... 123 results found"></asp:Label>
            </div>
            <div id="imgGridSection" class="nano">
            <div class="nano-content" >
                <asp:DataList ID="imageDataList" runat="server" RepeatDirection="Horizontal" RepeatColumns="6" CellPadding="6"> 
                    <ItemTemplate>
                        <table border="0" class="gridTable">
                            <tr>
                                <td align="center" valign="middle">
                                    <div class="imgHoverGrid">
                                        <asp:Image ID="Image" ToolTip='<%#  Eval("ToolTip") %>'  ClientIDMode="Static" runat="server" ImageUrl='<%#  Eval("ImageURL") %>' CssClass="imagesGrid"/>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            </div>
            
            <div id="detailSection" class="nano">
               
                <div class="nano-content">
                    <asp:GridView ID="gridMediaList" runat="server" Style="position:relative;float:left;" Width="99%" AutoGenerateColumns="false" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <Columns>
                            <asp:BoundField DataField="Name" ItemStyle-CssClass="nameOnDetailsGrid" HeaderText="Media Name" />
                            <asp:BoundField DataField="Type" ItemStyle-CssClass="typeOnDetailsGrid" HeaderText="Type" />
                            <asp:BoundField DataField="Year" ItemStyle-CssClass="yearOnDetailsGrid" HeaderText="Year" />
                            <asp:BoundField DataField="ImageURL" Visible ="false" />
                            <%--<asp:ImageField DataImageUrlField="ImageURL" ItemStyle-CssClass="imagesDetails" HeaderText="Image">
                            </asp:ImageField>--%>
                        </Columns>
                        <%--<RowStyle CssClass="rowOnDetailsGrid" />--%>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
                    <div id="imgContainer">

                    </div>
                </div>
            </div>
            <div id="listSection">
                List Section Data
            </div>
        </div>
        

    </div>

    <div id="mask">
    </div>

    <div id="mediaFloatingMiddleContainer">
        <div id="mediaInforContainer">
            <div id="mediaInformation" class="nano">
                <div id="closeButton"></div> 
                    <div class="nano-content">
                    <span class="mediaTitle"><strong>
                        <asp:Label ID="lblTitle" ClientIDMode="Static" runat="server">Twice - Cheer up</asp:Label></strong></span>
                    <table>
                        <tr><td><strong>Type:</strong> <asp:Label ID="lblType" ClientIDMode="Static" runat="server"></asp:Label>&nbsp;&nbsp;<strong>Year:</strong><asp:Label ID="lblYear" ClientIDMode="Static" runat="server"></asp:Label></td></tr>
                        <tr><td><strong>Description:</strong> <asp:Label ID="lblDescription" ClientIDMode="Static" runat="server"></asp:Label></td></tr>
                    </table>
                </div>
            </div>
            <div id="videoPlayer">
                <video id="our-video" loop="loop" controls="controls">
                      <source src="videos/TWICE - CHEER UP  M V.mp4" type="video/mp4" id="originVideo" />
                </video>
            </div>
        </div>
    </div>


    <div id="dvLoading">
        <img id="loading-image" class="loadingImage" src="images/loadingProcessing.gif" alt="Loading..." />
    </div>

    <script lang="javascript" type="text/javascript">
        
        //window.onload = function () { loadImages(); };

        function loadImages()
        {
            $(".imagesGrid").each(function (i, obj) {
                $(this).attr('src', 'ImageHandlerRequest.ashx?type=1');
            });
        }

        $(document).ready(function () {
            $('#mediaSelection input').change(function () {
                $("#txt_SearchValue").val("");
            });

            $('#displayMode input').change(function () {
                evaluateDisplayView();
            });

            evaluateDisplayView();

            makeGridViewClickable();

        });

        function makeGridViewClickable()
        {
            $("#<%=gridMediaList.ClientID%> tr").click(function(event){
                $('#imgContainer').empty();
                
                //var parentOffset = $(this).parent().paret().offset();
                ////or $(this).offset(); if you really just want the current element's offset
                //var relX = e.pageX - parentOffset.left;
                //var relY = e.pageY - parentOffset.top;

                var y = this.offsetTop;

                displayImageOnDetailsList($(this), event, y);

            });
        }

        function displayImageOnDetailsList(row,event, y)
        {
            var name = $("td", row).eq(0).html();
            
            var img = $('<img id="commonImage">');
            img.attr("src", "ImageHandlerRequest.ashx?op=GetPicByName&type=1&name=" + name);
            img.appendTo('#imgContainer');

            $("#imgContainer").css({ position: "absolute", visibility: "visible", top: y-150, left: 200 });

        }

        function DisplayDetails(row) {
            var message = "";
            message += "Name: " + $("td", row).eq(0).html();
            message += "\nType: " + $("td", row).eq(1).html();
            message += "\nYear: " + $("td", row).eq(2).html();
            alert(message);
        }

        function evaluateDisplayView()
        {
            var displayModeSelected = $("#displayMode input:radio:checked").val();
            if (displayModeSelected == 'Image Grid') {

                $("#imgGridSection").css('visibility', 'visible');
                $("#detailSection").css('visibility', 'hidden');
                $("#listSection").css('visibility', 'hidden');

            }
            else {
                if (displayModeSelected == 'Details') {
                    $("#imgGridSection").css('visibility', 'hidden');
                    $("#detailSection").css('visibility', 'visible');
                    $("#listSection").css('visibility', 'hidden');
                }
                else {
                    if (displayModeSelected == 'List') {
                        $("#imgGridSection").css('visibility', 'hidden');
                        $("#detailSection").css('visibility', 'hidden');
                        $("#listSection").css('visibility', 'visible');
                    }
                }
            }
        }



        $(window).load(function () {
            $('#dvLoading').fadeOut(100);
        });

        function resetImagesFunctions()
        {
            $(".imgHoverGrid").hover(function () {
                $(this).children("img").fadeTo(200, 1);
            }, function () {
                $(this).children("img").fadeTo(200, 0.40);
            });

            $(".imagesGrid").bind('click', function () {

                $("#mediaFloatingMiddleContainer").css({ 'visibility': 'visible' });
                $("#mask").css({ 'visibility': 'visible' });
                $("#our-video").find("#originVideo").attr("src", "videos/OH MY GIRL- LIAR LIAR (ver.2).mp4");
                $("#our-video").load();

            });

            $("#closeButton").bind('click', function () {

                $("#mediaFloatingMiddleContainer").css('visibility', 'hidden');
                $("#our-video").get(0).pause();
                $("#our-video").find("#originVideo").attr("src", "");
                $("#our-video").load();
                $("#mask").css({ 'visibility': 'hidden' });
            });
        }

        resetImagesFunctions();

        $(".nano").nanoScroller();

        function retrieveInformationAJAX(name)
        {
            var mediaName = name;
            var mediaSelected = $("#mediaSelection input:radio:checked").val();
            alert('Selected ' + mediaSelected);

            $.ajax({
                type: "POST",
                url: "MultimediaSelection.aspx/returnInformation",
                data: "{ name: '"+mediaName+"' , type:  '"+mediaSelected+"' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    //alert('Response');
                    //alert(response.d.VideoURL);
                    setValuesOfInformation(response.d);
                },
                failure: function (response)
                {
                    alert("Error on response " + response.d);
                }
            });
        }

        function setValuesOfInformation(response)
        {
            var name = response.Name;
            var type = response.Type;
            var year = response.Year;
            var description = response.Description;
            var URL = response.VideoURL;

            if (type == "")
            {
                type = "Not defined yet";
            }
            if (year == "0")
            {
                year = "Not defined yet";
            }
            if (description == "")
            {
                description = "Not defined yet";
            }

            $("#lblTitle").html(name);
            $("#lblType").html(type);
            $("#lblYear").html(year);
            $("#lblDescription").html(description);


            alert(URL);

            if (URL != "") {
                $("#videoPlayer").show();
                $("#our-video").find("#originVideo").attr("src", URL);
                $("#our-video").load();
            }
            else {
                alert('Hide');
                $("#videoPlayer").hide();
                $("#videoPlayer").css('visibility','hidden');
            }
         }

        // Get the instance of PageRequestManager.
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        // Add initializeRequest and endRequest
        prm.add_initializeRequest(prm_InitializeRequest);
        prm.add_endRequest(prm_EndRequest);

        function prm_InitializeRequest(sender, args) {
            $('#dvLoading').show();
        }

        function prm_EndRequest(sender, args) {
            $('#dvLoading').fadeOut(500);
            resetImagesFunctions();
            $(".nano").nanoScroller();
            evaluateDisplayView();
            makeGridViewClickable();
        }

    </script>

</asp:Content>
