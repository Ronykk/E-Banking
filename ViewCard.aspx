<%@ Page Title="" Language="C#" MasterPageFile="~/InvtMasterPage.master" AutoEventWireup="true" CodeFile="ViewCard.aspx.cs" Inherits="ViewCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
            font-family: "Poppins", sans-serif;
        }

        section {
            position: relative;
            min-height: 100vh;
            width: 100%;
            background: #14171e;
            display: flex;
            align-items: center;
            justify-content: center;
            color: #fff;
            perspective: 1000px;
        }

            section::before {
                content: "";
                position: absolute;
                height: 240px;
                width: 240px;
                border-radius: 50%;
                transform: translate(-150px, -100px);
                background: linear-gradient(90deg, #9c27b0, #f3f5f5);
            }

            section::after {
                content: "";
                position: absolute;
                height: 240px;
                width: 240px;
                border-radius: 50%;
                transform: translate(150px, 100px);
                background: linear-gradient(90deg, #9c27b0, #f3f5f5);
            }

        .container1 {
            position: relative;
            height: 225px;
            width: 375px;
            /*z-index: 80;*/
            transition: 0.6s;
            transform-style: preserve-3d;
            /*margin-top: 10%;*/
            /* margin-left: 34%;
            margin-top: 16%;*/
        }

            .container1:hover {
                transform: rotateY(180deg);
            }

            .container1 .card {
                position: absolute;
                height: 90%;
                width: 100%;
                padding: 25px;
                border-radius: 25px;
                backdrop-filter: blur(25px);
                background: rgba(255, 255, 255, 0.1);
                box-shadow: 0 25px 45px rgba(0, 0, 0, 0.25);
                border: 1px solid rgba(255, 255, 255, 0.1);
                backface-visibility: hidden;
                /*margin-top: 30%;*/
            }

        .front-face header,
        .front-face .logo {
            display: flex;
            align-items: center;
        }

        .front-face header {
            justify-content: space-between;
        }

        .front-face .logo img {
            width: 48px;
            margin-right: 10px;
        }

        h5 {
            font-size: 16px;
            font-weight: 400;
        }

        .front-face .chip {
            width: 50px;
        }

        .front-face .card-details {
            display: flex;
            margin-top: 40px;
            align-items: flex-end;
            justify-content: space-between;
        }

        h6 {
            font-size: 10px;
            font-weight: 400;
        }

        h5.number {
            font-size: 18px;
            letter-spacing: 1px;
        }

        h5.name {
            margin-top: 20px;
        }

        .card.back-face {
            border: none;
            padding: 15px 25px 25px 25px;
            transform: rotateY(180deg);
        }

            .card.back-face h6 {
                font-size: 8px;
            }

            .card.back-face .magnetic-strip {
                position: absolute;
                top: 40px;
                left: 0;
                height: 45px;
                width: 100%;
                background: #000;
            }

            .card.back-face .signature {
                display: flex;
                justify-content: flex-end;
                align-items: center;
                margin-top: 80px;
                height: 40px;
                width: 85%;
                border-radius: 6px;
                background: repeating-linear-gradient( #fff, #fff 3px, #efefef 0px, #efefef 9px );
            }

        .signature i {
            color: #000;
            font-size: 12px;
            padding: 4px 6px;
            border-radius: 4px;
            background-color: #fff;
            margin-right: -30px;
            z-index: -1;
        }

        .card.back-face h5 {
            font-size: 8px;
            margin-top: 15px;
        }

        .main_div {
            height: 80vh;
            display: flex;
            /*margin-left: 42%;*/
            align-items: center;
            justify-content: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main_div">
        <div class="row my-4">
            <div class="col-sm-4">
                <div class="container1">
                    <div class="card front-face">
                        <header>
                            <span class="logo">
                                <img src="img/logo.png" alt="" />
                                <h5>E-Banking Card</h5>
                            </span>
                            <img src="img/chip.png" alt="" class="chip" />
                        </header>

                        <div class="card-details">
                            <div class="name-number">
                                <h6>Card Number</h6>
                                <asp:Label runat="server" ID="lbl_cardno" Text="4063 2020 3070 5000" Style="color: black;"></asp:Label>
                                <h5 class="name"><i runat="server" style="font-family: 'Times New Roman'" id="iname">Mr. Steve Smith</i></h5>
                            </div>

                            <div class="valid-date">
                                <h6>Valid Thru</h6>
                                <h5>08/27</h5>
                            </div>
                        </div>
                    </div>

                    <div class="card back-face">
                        <h6>For customer service call +977 4343 4693 or email at
            ebankingserver@gmail.com
                        </h6>
                        <span class="magnetic-strip"></span>
                        <div class="signature"><i runat="server" id="icard">005</i></div>
                        <h5>This card issued by E-Bonking pursuant to a license from Visa USA. Inc. Use of this card is subject to the agreement. This card is the property of the issuer and must be returned upon request and may be revoked without notice. For customer service call 855-BANK-RCB.
If found, please return to:
RCB Bank P.O. Box 189, Claremore, OK 74018-0189


                        </h5>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

