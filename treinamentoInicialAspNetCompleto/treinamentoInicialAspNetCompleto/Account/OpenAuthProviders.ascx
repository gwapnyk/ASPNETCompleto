<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OpenAuthProviders.ascx.cs" Inherits="treinamentoInicialAspNetCompleto.Account.OpenAuthProviders" %>

<fieldset class="open-auth-providers">
    <legend>Efetue login usando outro serviço</legend>
    
    <asp:ListView runat="server" ID="providerDetails" ItemType="Microsoft.AspNet.Membership.OpenAuth.ProviderDetails"
        SelectMethod="GetProviderNames" ViewStateMode="Disabled">
        <ItemTemplate>
            <button type="submit" name="provider" value="<%#: Item.ProviderName %>"
                title="Log in using your <%#: Item.ProviderDisplayName %> account.">
                <%#: Item.ProviderDisplayName %>
            </button>
        </ItemTemplate>
    
        <EmptyDataTemplate>
            <div class="message-info">
                <p>Não há serviços de autenticação externos configurados. Consulte <a href="http://go.microsoft.com/fwlink/?LinkId=252803">este artigo</a> para obter detalhes sobre como configurar esse aplicativo ASP.NET para oferecer suporte ao logon através de serviços externos.</p>
            </div>
        </EmptyDataTemplate>
    </asp:ListView>
</fieldset>