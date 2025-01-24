$("#showCustomer").click(function () {
    $.ajax({
       
        url: "https://localhost:7109/Dashboard/CustomerList",
        type: "GET",
        success: function (data) {
            $('#contentLayout').html(data);
        }
    })

});

$("#showSKU").click(function () {
    $.ajax({

        url: "https://localhost:7109/Dashboard/SKUList",
        type: "GET",
        success: function (data) {
            $('#contentLayout').html(data);
        }
    })

});


function AddCustomer() {
    var model = {
        FirstName: $('#FirstName').val(),
        LastName: $('#LastName').val(),
        MobileNumber: $('#MobileNumber').val(),
        City: $('#City').val()
    };

    $.ajax({
        url: "https://localhost:7043/api/order/taker/SaveCustomer",
        data: JSON.stringify(model),
        type: "POST",
        contentType: 'application/json; charset=UTF-8',
        dataType: "json",
        //beforeSend: function (xhr) {   //Include the bearer token in header
        //    xhr.setRequestHeader("Authorization", 'Bearer ' + result);

        //},
        success: function (result) {
            $('#addCustomerModal').modal('hide');
            //toastr.success("Added Clinic", 'Successfully Added', { timeOut: 2000, showMethod: "slideDown", hideMethod: "slideUp" });

            $('#FirstName').val('');
            $('#LastName').val('');
            $('#MobileNumber').val('');
            $('#City').val('');
            $.ajax({

                url: "https://localhost:7109/Dashboard/CustomerList",
                type: "GET",
                success: function (data) {
                    $('#contentLayout').html(data);
                }
            })

        },
        error: function (errormessage) {
            console.log(errormessage);
            //toastr.error(errormessage.responseText, 'Error', { timeOut: 2000, showMethod: "slideDown", hideMethod: "slideUp" });
        }
    });

}

function openUpdateCustomerModal(customerId) {
    var request = {
        CustomerId: customerId
    };
    //console.log(request);
    $.ajax({
        url: 'https://localhost:7043/api/order/taker/GetCustomerById',
        type: 'POST',
        contentType: 'application/json; charset=UTF-8',
        dataType: "json",
        data: JSON.stringify(request),
        success: function (customer) {
            //console.log(customer);
            $('#customerId').val(customerId);
            $('#Update_LastName').val(customer.customer.lastName);
            $('#Update_FirstName').val(customer.customer.firstName);
            $('#Update_MobileNumber').val(customer.customer.mobileNumber);
            $('#Update_City').val(customer.customer.city);
           // $('#Update_CustomerIsActive').val(customer.customer.isActive);
            $("#Update_CustomerIsActive").prop("checked", customer.customer.isActive);
            $('#updateCustomerModal').modal('show');
        },
        error: function (errormessage) {
            console.log(errormessage);
        }
    });
}

function UpdateCustomer() {
    var model = {
        Id: $('#customerId').val(),
        FirstName: $('#Update_FirstName').val(),
        LastName: $('#Update_LastName').val(),
        MobileNumber: $('#Update_MobileNumber').val(),
        City: $('#Update_City').val(),
        IsActive: $('#Update_CustomerIsActive').prop('checked')
    };

    $.ajax({
        url: "https://localhost:7043/api/order/taker/UpdateCustomer",
        data: JSON.stringify(model),
        type: "POST",
        contentType: 'application/json; charset=UTF-8',
        dataType: "json",
        //beforeSend: function (xhr) {   //Include the bearer token in header
        //    xhr.setRequestHeader("Authorization", 'Bearer ' + result);

        //},
        success: function (result) {
            $('#updateCustomerModal').modal('hide');
            //toastr.success("Added Clinic", 'Successfully Added', { timeOut: 2000, showMethod: "slideDown", hideMethod: "slideUp" });

            $.ajax({

                url: "https://localhost:7109/Dashboard/CustomerList",
                type: "GET",
                success: function (data) {
                    $('#contentLayout').html(data);
                }
            })
        },
        error: function (errormessage) {
            console.log(errormessage);
            //toastr.error(errormessage.responseText, 'Error', { timeOut: 2000, showMethod: "slideDown", hideMethod: "slideUp" });
        }
    });

}


function AddSKU() {
    var request = {
        Name: $('#SKUName').val(),
        Code: $('#SKUCode').val(),
        UnitPrice: $('#SKUUnitPrice').val(),
        SKUImage: $('#SKUImage').val()
    };
    console.log(request);
    $.ajax({
        url: "https://localhost:7043/api/order/taker/SaveSKU",
        data: JSON.stringify(request),
        type: "POST",
        contentType: 'application/json; charset=UTF-8',
        dataType: "json",
       
        success: function (result) {
            $('#addSkuModal').modal('hide');

            $('#SKUName').val('');
            $('#SKUCode').val('');
            $('#SKUUnitPrice').val('');
            $.ajax({

                url: "https://localhost:7109/Dashboard/SKUList",
                type: "GET",
                success: function (data) {
                    $('#contentLayout').html(data);
                }
            })

        },
        error: function (errormessage) {

            console.log(errormessage);
        }
    });
   

}


function openUpdateSKUModal(skuId) {
    var request = {
        SKUId: skuId,
        Name:''
    };
    //console.log(request);
    $.ajax({
        url: 'https://localhost:7043/api/order/taker/GetSKUById',
        type: 'POST',
        contentType: 'application/json; charset=UTF-8',
        dataType: "json",
        data: JSON.stringify(request),
        success: function (sku) {
            //console.log(sku);
            $('#skuId').val(skuId);
            $('#Update_Name').val(sku.sku.name);
            $('#Update_Code').val(sku.sku.code);
            $('#Update_UnitPrice').val(sku.sku.unitPrice);
            $("#Update_SKUIsActive").prop("checked", sku.sku.isActive);
            $('#updateSkuModal').modal('show');
        },
        error: function (errormessage) {
            console.log(errormessage);
        }
    });
}


function UpdateSKU() {
    var model = {
        Id: $('#skuId').val(),
        Name: $('#Update_Name').val(),
        Code: $('#Update_Code').val(),
        UnitPrice: $('#Update_UnitPrice').val(),
        SKUImage: $('#Update_SKUImage').val(),
        IsActive: $('#Update_SKUIsActive').prop('checked')
    };

    $.ajax({
        url: "https://localhost:7043/api/order/taker/UpdateSKU",
        data: JSON.stringify(model),
        type: "POST",
        contentType: 'application/json; charset=UTF-8',
        dataType: "json",
        success: function (result) {
            $('#updateSkuModal').modal('hide');
           
            $.ajax({

                url: "https://localhost:7109/Dashboard/SKUList",
                type: "GET",
                success: function (data) {
                    $('#contentLayout').html(data);
                }
            })
        },
        error: function (errormessage) {
            console.log(errormessage);
        }
    });

}

$("#PurchaseItem_Quantity").on("input", function () {
    var initialPrice = $("#PurchaseItem_UnitPrice").val();
    if ($("#PurchaseItem_Quantity").val() > 1) {
        this.value = this.value.replace(/[^0-9\.]/g, '');
        //console.log(initialPrice);
        var quantity = this.value;
        $("#PurchaseItem_Price").val(quantity * initialPrice);
    } else {
        $("#PurchaseItem_Price").val(initialPrice);
    }
});

function AddOrder() {

    var orderRequest = {
        CustomerId: $('#Order_CustomerId').val(),
        DateOfDelivery: $('#Order_DeliveryDate').val(),
        Status: $('#OrderStatus').val(),
        AmountDue: $('#Order_AmountDue').val()
    };
   // console.log(orderRequest);
    $.ajax({
        url: "https://localhost:7043/api/order/taker/SavePurchaseOrder",
        data: JSON.stringify(orderRequest),
        type: "POST",
        contentType: 'application/json; charset=UTF-8',
        dataType: "json",

        success: function (result) {
            $('#addPurchaseItem').removeAttr("disabled")
            $("#messageLayout").toggle();
           
        },
        error: function (errormessage) {

            console.log(errormessage);
        }
    });


}




function UpdateOrder() {

    var orderRequest = {
        Id: $('#UpdateOrderId').val(), 
        CustomerId: $('#UpdateOrderNameId').val(),
        DateOfDelivery: $('#UpdateDeliveryDate').val(),
        Status: $('#UpdateOrderStatus').val(),
        AmountDue: $('#UpdateOrderAmount').val(),
        IsActive: $('#UpdateOrderIsActive').prop('checked')
    };

    console.log(orderRequest);
    $.ajax({
        url: "https://localhost:7043/api/order/taker/UpdatePurchaseOrder",
        data: JSON.stringify(orderRequest),
        type: "POST",
        contentType: 'application/json; charset=UTF-8',
        dataType: "json",
        
        success: function (result) {
           
            window.location.replace("https://localhost:7109/Dashboard/OrdersList");

        },
        error: function (errormessage) {
            console.log(errormessage);
            //toastr.error(errormessage.responseText, 'Error', { timeOut: 2000, showMethod: "slideDown", hideMethod: "slideUp" });
        }
    });

}

function UpdateOrderAmountDue() {

    var orderRequest = {
        Id: $('#Order_NewId').val(),
        CustomerId: $('#Order_CustomerId').val(),
        DateOfDelivery: $('#Order_DeliveryDate').val(),
        Status: $('#OrderStatus').val(),
        AmountDue: $('#Order_AmountDue').val(),
        IsActive:true
    };

    console.log(orderRequest);
    $.ajax({
        url: "https://localhost:7043/api/order/taker/UpdatePurchaseOrder",
        data: JSON.stringify(orderRequest),
        type: "POST",
        contentType: 'application/json; charset=UTF-8',
        dataType: "json",

        success: function (result) {

            window.location.replace("https://localhost:7109/Dashboard/OrdersList");

        },
        error: function (errormessage) {
            console.log(errormessage);
            //toastr.error(errormessage.responseText, 'Error', { timeOut: 2000, showMethod: "slideDown", hideMethod: "slideUp" });
        }
    });

}




function AddItem() {
    var itemRequest = {
        PurchaseOrderId: $('#Order_NewId').val(),
        SKUId: $('#PurchaseItem_SKUId').val(),
        Quantity: $('#PurchaseItem_Quantity').val(),
        Price: $('#PurchaseItem_Price').val()
    };

    //var purchaseOrderId = $('#Order_NewId').val();
    $.ajax({
        url: "https://localhost:7043/api/order/taker/SavePurchaseItem",
        data: JSON.stringify(itemRequest),
        type: "POST",
        contentType: 'application/json; charset=UTF-8',
        dataType: "json",

        success: function (result) {
            var purchaseOrderId = $('#Order_NewId').val();
            console.log(purchaseOrderId);
            $.ajax({

                url: "https://localhost:7109/Dashboard/PurchaseItemList",
                type: "GET",
                data: {
                    purchaseOrderId: purchaseOrderId,

                },
                success: function (data) {
                    $('#itemsLayout').html(data);



                    var purchaseItemRequest = {
                        PurchaseOrderId: purchaseOrderId
                    };
                    console.log(purchaseItemRequest);
                    $.ajax({
                        url: "https://localhost:7043/api/order/taker/GetPurchaseItemsByOrder",
                        data: JSON.stringify(purchaseItemRequest),
                        type: "POST",
                        contentType: 'application/json; charset=UTF-8',
                        dataType: "json",

                        success: function (result) {
                            console.log(result.totalPurchaseAmount);
                            $('#Order_AmountDue').val(result.totalPurchaseAmount);
                            $('#initialSaveButton').hide();

                        },
                        error: function (errormessage) {

                            console.log(errormessage);
                        }
                    });

                },
                error: function (errormessage) {

                    console.log(errormessage);
                }
            })

            $('#addPurchaseItemModal').modal('hide');

            $('#PurchaseItem_SKUName').val('');
            $('#PurchaseItem_Quantity').val('');
            $('#PurchaseItem_Price').val('');

        },
        error: function (errormessage) {

            console.log(errormessage);
        }
    });
}

function openUpdatePurchaseItemModal(purchaseItemId) {
    var request = {
        PurchaseItemId: purchaseItemId
    };
    console.log(request);
    $.ajax({
        url: 'https://localhost:7043/api/order/taker/GetPurchaseItemById',
        type: 'POST',
        contentType: 'application/json; charset=UTF-8',
        dataType: "json",
        data: JSON.stringify(request),
        success: function (item) {
            console.log(item);
            $('#updatePurchaseItemModal').modal('show');
            $('#purchaseItemId').val(purchaseItemId);
            
            $('#UpdatePurchaseItemSKUName').val(item.purchaseItem.sku);
            $('#UpdatePurchaseItemSKUId').val(item.purchaseItem.skuId);
            $('#UpdatePurchaseItemQuantity').val(item.purchaseItem.quantity);
            $('#UpdatePurchaseItemPrice').val(item.purchaseItem.price);
            $('#UpdateUnitPrice').val(item.purchaseItem.unitPrice);
            $('#UpdatePurchaseOrderId').val(item.purchaseItem.purchaseOrderId);
            
        },
        error: function (errormessage) {
            console.log(errormessage);
        }
    });
}

function UpdateItem() {
    var itemRequest = {
        Id: $('#purchaseItemId').val(),
        PurchaseOrderId: $('#UpdatePurchaseOrderId').val(),
        SKUId: $('#UpdatePurchaseItemSKUId').val(),
        Quantity: $('#UpdatePurchaseItemQuantity').val(),
        Price: $('#UpdatePurchaseItemPrice').val()
    };

    //var purchaseOrderId = $('#Order_NewId').val();
    $.ajax({
        url: "https://localhost:7043/api/order/taker/UpdatePurchaseItem",
        data: JSON.stringify(itemRequest),
        type: "POST",
        contentType: 'application/json; charset=UTF-8',
        dataType: "json",

        success: function (result) {
            var purchaseOrderId = $('#purchaseItemId').val();
            console.log(purchaseOrderId);
            $.ajax({

                url: "https://localhost:7109/Dashboard/PurchaseItemList",
                type: "GET",
                data: {
                    purchaseOrderId: purchaseOrderId,

                },
                success: function (data) {
                    $('#itemsLayout').html(data);



                    var purchaseItemRequest = {
                        PurchaseOrderId: purchaseOrderId
                    };
                    console.log(purchaseItemRequest);
                    $.ajax({
                        url: "https://localhost:7043/api/order/taker/GetPurchaseItemsByOrder",
                        data: JSON.stringify(purchaseItemRequest),
                        type: "POST",
                        contentType: 'application/json; charset=UTF-8',
                        dataType: "json",

                        success: function (result) {
                            console.log(result.totalPurchaseAmount);
                            $('#UpdateOrderAmount').val(result.totalPurchaseAmount);
                            $('#initialSaveButton').hide();

                        },
                        error: function (errormessage) {

                            console.log(errormessage);
                        }
                    });

                },
                error: function (errormessage) {

                    console.log(errormessage);
                }
            })

            $('#updatePurchaseItemModal').modal('hide');

            $('#UpdatePurchaseItemSKUName').val('');
            $('#UpdatePurchaseItemQuantity').val('');
            $('#UpdatePurchaseItemPrice').val('');

        },
        error: function (errormessage) {

            console.log(errormessage);
        }
    });
}

$("#UpdatePurchaseItemQuantity").on("input", function () {
    var initialPrice = $("#UpdateUnitPrice").val();
    if ($("#UpdatePurchaseItemQuantity").val() > 1) {
        this.value = this.value.replace(/[^0-9\.]/g, '');
        console.log(initialPrice);
        var quantity = this.value;
        $("#UpdatePurchaseItemPrice").val(quantity * initialPrice);
    } else {
        $("#UpdatePurchaseItemPrice").val(initialPrice);
    }
});