using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Abstracts;
using Microsoft.AspNetCore.OData.Extensions;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Query.Validator;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using MyRent.API.Business.Model;
using MyRent.API.Rest;

namespace MyRent.API.Controllers
{
    public class ApartmentsController : ODataController
    {
        private readonly Entities _entites;
        public ApartmentsController(Entities entites)
        {
            _entites = entites;
        }

        private ODataQueryOptions GetOdataQueryOption()
        {
            IODataFeature odataFeature = Request.ODataFeature();
            Type clrEntityType = ODataBuilder.GetClrType(odataFeature.Path, odataFeature.Model);
            ODataQueryOptions option = new ODataQueryOptions(new ODataQueryContext(odataFeature.Model, clrEntityType, odataFeature.Path), Request);

            option.Validate(new ODataValidationSettings()
            {
                AllowedQueryOptions = AllowedQueryOptions.Expand | AllowedQueryOptions.Select | AllowedQueryOptions.OrderBy | AllowedQueryOptions.Top | AllowedQueryOptions.Skip | AllowedQueryOptions.Count | AllowedQueryOptions.Filter,
                AllowedArithmeticOperators = AllowedArithmeticOperators.All,
                AllowedFunctions = AllowedFunctions.AllFunctions, // AllowedFunctions.All,
                AllowedLogicalOperators = AllowedLogicalOperators.All,
                MaxOrderByNodeCount = 2,
                MaxTop = 100,
                MaxExpansionDepth = 0 //100
            });

            return option;
        }

        [EnableQuery]
        [HttpGet]
        public IActionResult Get(String key)
        {
            ODataQueryOptions option = GetOdataQueryOption();


            //_entites.Apartments
            var query = _entites.Apartments.Where(r => r.ID.ToString() == key)
                .Join(
                _entites.Owners,
                (outer) => outer.OwnerID,
                (inner) => inner.ID,
                (outer, inner) => new
                {
                    Owner = inner,
                    Apartment = outer,
                }
                )
                .Join(
                _entites.Regions,
                (outer) => outer.Apartment.RegionID,
                (inner) => inner.ID,
                 (outer, inner) => new
                 {
                     Region = inner,
                     outer.Owner,
                     outer.Apartment,
                 })
                 .Join(
                    _entites.InterierObjects,
                    (outer) => outer.Apartment.InterierObjectID,
                    (inner) => inner.ID,
                     (outer, inner) => new
                     {
                         Region = inner,
                         outer.Owner,
                         outer.Apartment,
                         InterierObject = inner
                     })
                 .Select(s => new Apartment
                 {
                     ID = s.Apartment.ID,
                     Name = s.Apartment.Name,
                     Address = s.Apartment.Address,
                     Type = s.Apartment.Type,
                     ReservedTo = s.Apartment.ReservedTo,
                     ReservedFrom = s.Apartment.ReservedFrom,
                     OwnerID = s.Apartment.OwnerID,
                     RegionID = s.Apartment.RegionID,
                     InterierObjectID = s.Apartment.InterierObjectID,
                     Owner = s.Apartment.Owner,
                     Region = s.Apartment.Region,
                     InterierObject = s.Apartment.InterierObject
                 });

            //IQueryable result = option.ApplyTo(query);
            return Ok(query);
        }

        [EnableQuery]
        [HttpGet]
        public IActionResult Get()
        {
            //_entites.Apartments
            var query = _entites.Apartments
                .Join(
                _entites.Owners,
                (outer) => outer.OwnerID,
                (inner) => inner.ID,
                (outer, inner) => new
                {
                    Owner = inner,
                    Apartment = outer,
                }
                )
                .Join(
                _entites.Regions,
                (outer) => outer.Apartment.RegionID,
                (inner) => inner.ID,
                 (outer, inner) => new
                 {
                     Region = inner,
                     outer.Owner,
                     outer.Apartment,
                 })
                 .Join(
                    _entites.InterierObjects,
                    (outer) => outer.Apartment.InterierObjectID,
                    (inner) => inner.ID,
                     (outer, inner) => new
                     {
                         Region = inner,
                         outer.Owner,
                         outer.Apartment,
                         InterierObject = inner
                     })
                 .Select(s => new Apartment
                 { 
                     ID = s.Apartment.ID,
                     Name = s.Apartment.Name,
                     Address = s.Apartment.Address,
                     Type = s.Apartment.Type,
                     ReservedTo = s.Apartment.ReservedTo,
                     ReservedFrom = s.Apartment.ReservedFrom,
                     OwnerID = s.Apartment.OwnerID,
                     RegionID = s.Apartment.RegionID,
                     InterierObjectID = s.Apartment.InterierObjectID,
                     Owner = s.Apartment.Owner,
                     Region = s.Apartment.Region,
                     InterierObject = s.Apartment.InterierObject
                 });

            return Ok(query);
        }
    }
}
