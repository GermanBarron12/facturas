using facturas.Models;
using Microsoft.AspNetCore.Components.Forms;
using System.Reflection.Emit;

@page "/nueva-factura"
@using facturas.Data
@using facturas.Models
@inject FacturasDb Db
@inject NavigationManager Nav
@rendermode InteractiveServer

<h1>Nueva Factura</h1>

<EditForm Model="@factura" OnValidSubmit="@Guardar">
    <DataAnnotationsValidator />
    <ValidationSummary />

    <div class= "mb-3" >
        < label > Fecha:</ label >
        < InputDate @bind - Value = "factura.Fecha" class= "form-control" />
    </ div >

    < div class= "mb-3" >
        < label > Cliente:</ label >
        < InputText @bind - Value = "factura.NombreCliente" class= "form-control" />
    </ div >

    < h3 > Artículos </ h3 >

    @foreach(var art in factura.Articulos)
    {
        < div class= "card mb-2 p-3" >
            < div class= "row" >
                < div class= "col-md-4" >
                    < label > Descripción:</ label >
                    < InputText @bind - Value = "art.Descripcion" class= "form-control" />
                </ div >
                < div class= "col-md-2" >
                    < label > Cantidad:</ label >
                    < InputNumber @bind - Value = "art.Cantidad" class= "form-control" />
                </ div >
                < div class= "col-md-2" >
                    < label > Precio:</ label >
                    < InputNumber @bind - Value = "art.Precio" class= "form-control" />
                </ div >
                < div class= "col-md-2" >
                    < label > Subtotal:</ label >
                    < input type = "text" class= "form-control" readonly value= "$@((art.Cantidad * art.Precio).ToString("N2"))" />
                </div>
                <div class= "col-md-2" >
                    < label > &nbsp;</ label >
                    < button type = "button" class= "btn btn-danger w-100" @onclick = "() => factura.Articulos.Remove(art)" >
                        Quitar
                    </ button >
                </ div >
            </ div >
        </ div >
    }

    < button type = "button" class= "btn btn-secondary mb-3" @onclick = "AgregarArticulo" >
        +Agregar Artículo
    </ button >

    < div class= "alert alert-info" >
        < h4 > Total: $@CalcularTotal().ToString("N2") </ h4 >
    </ div >

    < button type = "submit" class= "btn btn-success" > Guardar Factura </ button >
    < a href = "/facturas" class= "btn btn-secondary" > Cancelar </ a >
</ EditForm >

@code {
    private Factura factura = new Factura();

protected override void OnInitialized()
{
    // Empezar con un artículo vacío
    AgregarArticulo();
}

private void AgregarArticulo()
{
    factura.Articulos.Add(new Articulo());
}

private decimal CalcularTotal()
{
    return factura.Articulos.Sum(a => a.Cantidad * a.Precio);
}

private async Task Guardar()
{
    // Calcular el total
    factura.Total = CalcularTotal();

    // Guardar en la base de datos
    Db.Facturas.Add(factura);
    await Db.SaveChangesAsync();

    // Regresar a la lista
    Nav.NavigateTo("/facturas");
}
}