using facturas.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading;

@page "/facturas"
@using facturas.Data
@using facturas.Models
@using Microsoft.EntityFrameworkCore
@inject FacturasDb Db
@rendermode InteractiveServer

<h1>Mis Facturas</h1>

<a href="/nueva-factura" class= "btn btn-primary mb-3" > +Nueva Factura </ a >

@if(facturas == null)
{
    < p > Cargando...</ p >
}
else if (facturas.Count == 0)
{
    < p > No hay facturas. ¡Crea tu primera factura!</ p >
}
else
{
    < table class= "table" >
        < thead >
            < tr >
                < th > ID </ th >
                < th > Fecha </ th >
                < th > Cliente </ th >
                < th > Total </ th >
            </ tr >
        </ thead >
        < tbody >
            @foreach(var factura in facturas)
            {
                < tr >
                    < td > @factura.Id </ td >
                    < td > @factura.Fecha.ToString("dd/MM/yyyy") </ td >
                    < td > @factura.NombreCliente </ td >
                    < td > $@factura.Total.ToString("N2") </ td >
                </ tr >
            }
        </ tbody >
    </ table >
}

@code {
    private List<Factura>? facturas;

protected override async Task OnInitializedAsync()
{
    // Traer todas las facturas de la base de datos
    facturas = await Db.Facturas.ToListAsync();
}
}