// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Dynamic;
using JsonPatchSample.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace JsonPatchSample.Controllers
{
    [Route("jsonpatch/[action]")]
    public class HomeController : Controller
    {
        #region snippet_PatchAction
        [HttpPatch]
        public IActionResult JsonPatchWithModelState(
            [FromBody] JsonPatchDocument<Customer> patchDoc)
        {
            if (patchDoc != null)
            {
                var customer = CreateCustomer();

                patchDoc.ApplyTo(customer, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                return new ObjectResult(customer);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        #endregion

        [HttpPatch]
        public IActionResult JsonPatchWithModelStateAndPrefix(
            [FromBody] JsonPatchDocument<Customer> patchDoc,
            string prefix)
        {
            var customer = CreateCustomer();

            patchDoc.ApplyTo(customer, ModelState, prefix);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return new ObjectResult(customer);
        }

        [HttpPatch]
        public IActionResult JsonPatchWithoutModelState([FromBody] JsonPatchDocument<Customer> patchDoc)
        {
            var customer = CreateCustomer();

            patchDoc.ApplyTo(customer);

            return new ObjectResult(customer);
        }

        [HttpPatch]
        public IActionResult JsonPatchForProduct([FromBody] JsonPatchDocument<Product> patchDoc)
        {
            var product = new Product();

            patchDoc.ApplyTo(product);

            return new ObjectResult(product);
        }

        #region snippet_Dynamic
        [HttpPatch]
        public IActionResult JsonPatchForDynamic([FromBody]JsonPatchDocument patch)
        {
            dynamic obj = new ExpandoObject();
            patch.ApplyTo(obj);

            return Ok(obj);
        }
        #endregion

        private Customer CreateCustomer()
        {
            return new Customer
            {
                CustomerName = "John",
                Orders = new List<Order>()
                {
                    new Order
                    {
                        OrderName = "Order0"
                    },
                    new Order
                    {
                        OrderName = "Order1"
                    }
                }
            };
        }
    }
}
