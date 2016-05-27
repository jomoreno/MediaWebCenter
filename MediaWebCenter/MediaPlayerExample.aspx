<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MediaPlayerExample.aspx.cs" Inherits="MediaWebCenter.MediaPlayerExample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="scripts/jquery-1.12.4.min.js"></script>
    <link href="styles/examples.css" rel="stylesheet" />
    <script src="scripts/jquery.nanoscroller.min.js"></script>
    <link href="styles/nanoscroller.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        Algo de HTML escribo en el background

        <div id="Clickable">

            Click Here

        </div>

    <div>
        <div id="mask">
        </div>

        <div id="mediaFloatingMiddleContainer">
            <div id="mediaInforContainer">
                <div id="mediaInformation" class="nano">
                    <div id="closeButton"></div> 
                     <div class="nano-content">
                        <span class="mediaTitle"><strong>Twice - Cheer up</strong></span>
                        <table>
                            <tr><td><strong>Type:</strong> Comedy <strong>Year:</strong>2016</td></tr>
                            <tr><td><strong>Description:</strong> <br/> test test test test <br/>test test test test test test test test test test test test test test test test</td></tr>
                        </table>
                    </div>
                </div>
                <div id="videoPlayer">
                    <video id="our-video" controls="controls">
                        <source src="videos/TWICE - CHEER UP  M V.mp4" type="video/mp4" />
                        <source src="videos/TWICE - CHEER UP  M V.mp4" type="video/mp4" />
                    </video>
                </div>
            </div>
        </div>
            
    </div>

    <script type="text/javascript">

        //$(document).ready(function () {
        //    $('video').videoPlayer({
        //        'playerWidth': 0.95,
        //        'videoClass': 'video'
        //    });
        //});

        $(".nano").nanoScroller();

        $("#closeButton").bind('click', function () {

            $("#mediaFloatingMiddleContainer").css('visibility', 'hidden');
            $("#our-video").get(0).pause();
            $("#our-video").get(0).src = "";

        })

        $("#Clickable").bind('click', function () {

            $("#mediaFloatingMiddleContainer").css('visibility', 'visible');

        });



    </script>


    </form>
</body>
</html>
