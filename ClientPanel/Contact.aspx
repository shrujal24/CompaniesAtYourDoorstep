
<%@ Page Title="" Language="C#" MasterPageFile="~/Content/ClientMaster.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="ClientPanel_Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">
     <div class="hero-wrap hero-wrap-2" style="background-image: url('../Content/images/bg_1.jpg');" data-stellar-background-ratio="0.5">
      <div class="overlay"></div>
      <div class="container">
        <div class="row no-gutters slider-text align-items-end justify-content-start">
          <div class="col-md-12 ftco-animate text-center mb-5 fadeInUp ftco-animated">
          	<p class="breadcrumbs mb-0"><span class="mr-3"><a href="index.aspx">Home <i class="ion-ios-arrow-forward"></i></a></span> <span>Contact</span></p>
            <h1 class="mb-3 bread">Contact us</h1>
          </div>
        </div>
      </div>
    </div>

		<section class="ftco-section contact-section bg-light">
      <div class="container">
        <div class="row d-flex mb-5 contact-info">
          <div class="col-md-12 mb-4">
            <h2 class="h3">Contact Information</h2>
          </div>
          <div class="w-100"></div>
          <div class="col-md-3">
            <p><span>Address:</span> Darshan Institute of Engineering and Technology, Rajkot-Morbi Highway, Rajkot</p>
          </div>
          <div class="col-md-3">
            <p><span>Phone:</span> <a href="tel://7567576001">+91 7567576001</a></p>
          </div>
          <div class="col-md-3">
            <p><span>Email:</span> <a href="mailto:cayd@darshan.ac.in">cayd@darshan.ac.in</a></p>
          </div>
          <div class="col-md-3">
            <p><span>Website</span> <a href="#">cayd.com</a></p>
          </div>
        </div>
        <div class="row block-9">
          <div class="col-md-6 order-md-last d-flex">
            <div action="#" class="bg-white p-5 contact-form">
              <div class="form-group">
                <asp:TextBox ID="TextBox1" runat="server" type="text" class="form-control" placeholder="Your Name"/>
              </div>
              <div class="form-group">
                <asp:TextBox ID="TextBox2" runat="server" type="text" class="form-control" placeholder="Your Email"/>
              </div>
              <div class="form-group">
                <asp:TextBox ID="TextBox3" runat="server" type="text" class="form-control" placeholder="Subject"/>
              </div>
              <div class="form-group">
                <asp:TextBox ID="TextBox4" runat="server" TextMode="MultiLine" Columns="30"  Rows="7" class="form-control" placeholder="Message"/>
              </div>
              <div class="form-group">
                <asp:TextBox ID="TextBox5" runat="server" type="submit" value="Send Message" class="btn btn-primary py-3 px-5"/>
              </div>
            </div>
          
          </div>

          <div class="col-md-6 d-flex">
          	<div id="map" class="bg-white"></div>
          </div>
        </div>
      </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" Runat="Server">
</asp:Content>

