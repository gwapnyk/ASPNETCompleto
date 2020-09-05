<%@ Page Title="Sobre" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="treinamentoInicialAspNetCompleto.About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>A página de descrição do seu aplicativo.</h2>
    </hgroup>

    <article>
        <p>        
            Use esta área para fornecer informações adicionais.
        </p>

        <p>        
            Use esta área para fornecer informações adicionais.
        </p>

        <p>        
            Use esta área para fornecer informações adicionais.
        </p>
    </article>

    <aside>
        <h3>Título</h3>
        <p>        
            Use esta área para fornecer informações adicionais.
        </p>
        <ul>
            <li><a runat="server" href="~/">Home</a></li>
            <li><a runat="server" href="~/About.aspx">About</a></li>
            <li><a runat="server" href="~/Contact.aspx">Contact</a></li>
        </ul>
    </aside>
</asp:Content>