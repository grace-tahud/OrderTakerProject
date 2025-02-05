$(document).ready(function () {
    $("#Customer_FullName").autocomplete({
        source: function (request, response) {
            //console.log('customer' + request.term);

            var request = {
                Name: request.term
            };
            $.ajax({
                url: 'https://localhost:7043/api/order/taker/GetCustomerByName',
                data: JSON.stringify(request),
                type: "POST",
                contentType: 'application/json; charset=UTF-8',
                dataType: "json", 
                success: function (data) {
                    //console.log(data);
                    response($.map(data, function (customer) {
                        //console.log(customer);
                        if (customer != null) {
                            return {
                                label: customer.fullName,
                                value: customer.fullName,
                                id: customer.id

                            };
                        } else {
                            return {
                                label: '',
                                value: '',
                                id: 0

                            };
                        }
                        
                        
                    }));
                }, 
               
                error: function (xhr, textStatus, errorThrown) {
                    console.error('Error in fetching autocomplete data: ', textStatus);
                }
            });
        },
        select: function (event, ui) {
            $("#Order_CustomerId").val(ui.item.id);
        }
        
    });

    $("#PurchaseItem_SKUName").autocomplete({
        appendTo: "#addPurchaseItemModal",
        source: function (request, response) {
            //console.log(request.term);

            var request = {
                Name: request.term
            };
            $.ajax({
                url: 'https://localhost:7043/api/order/taker/GetSKUByName',
                data: JSON.stringify(request),
                type: "POST",
                contentType: 'application/json; charset=UTF-8',
                dataType: "json",
                success: function (data) {
                    //console.log(data);
                    response($.map(data, function (sku) {
                        //console.log(sku);
                        if (sku != null) {
                            return {
                                label: sku.name,
                                value: sku.name,
                                id: sku.id,
                                price: sku.unitPrice

                            };
                        } else {
                            return {
                                label: '',
                                value: '',
                                id: 0,
                                price: 0

                            };
                        }
                        

                    }));
                },

                error: function (xhr, textStatus, errorThrown) {
                    console.error('Error in fetching autocomplete data: ', textStatus);
                }
            });
        },
        select: function (event, ui) {
            $("#PurchaseItem_SKUId").val(ui.item.id);
            $("#PurchaseItem_Quantity").val(1);
            
            $("#PurchaseItem_Price").val(ui.item.price);
            $("#PurchaseItem_UnitPrice").val(ui.item.price);
            
        }

    });
});

$(document).ready(function () {
    $("#UpdateOrderName").autocomplete({
        source: function (request, response) {
            //console.log('customer' + request.term);

            var request = {
                Name: request.term
            };
            $.ajax({
                url: 'https://localhost:7043/api/order/taker/GetCustomerByName',
                data: JSON.stringify(request),
                type: "POST",
                contentType: 'application/json; charset=UTF-8',
                dataType: "json",
                success: function (data) {
                    //console.log(data);
                    response($.map(data, function (customer) {
                        //console.log(customer);
                        if (customer != null) {
                            return {
                                label: customer.fullName,
                                value: customer.fullName,
                                id: customer.id

                            };
                        } else {
                            return {
                                label: '',
                                value: '',
                                id: 0

                            };
                        }

                    }));
                },

                error: function (xhr, textStatus, errorThrown) {
                    console.error('Error in fetching autocomplete data: ', textStatus);
                }
            });
        },
        select: function (event, ui) {
            $("#UpdateOrderNameId").val(ui.item.id);
        }

    });

    $("#UpdatePurchaseItemSKUName").autocomplete({
        appendTo: "#updatePurchaseItemModal",
        source: function (request, response) {
            var request = {
                Name: request.term
            };
            $.ajax({
                url: 'https://localhost:7043/api/order/taker/GetSKUByName',
                data: JSON.stringify(request),
                type: "POST",
                contentType: 'application/json; charset=UTF-8',
                dataType: "json",
                success: function (data) {
                    //console.log(data);
                    response($.map(data, function (sku) {
                        //console.log(sku);
                        if (sku != null) {
                            return {
                                label: sku.name,
                                value: sku.name,
                                id: sku.id,
                                price: sku.unitPrice

                            };
                        } else {
                            return {
                                label: '',
                                value: '',
                                id: 0,
                                price: 0

                            };
                        }

                    }));
                },

                error: function (xhr, textStatus, errorThrown) {
                    console.error('Error in fetching autocomplete data: ', textStatus);
                }
            });
        },
        select: function (event, ui) {
            $("#UpdatePurchaseItemSKUId").val(ui.item.id);
            $("#UpdatePurchaseItemQuantity").val(1);

            $("#UpdatePurchaseItemPrice").val(ui.item.price);
            $("#UpdatePurchaseItemUnitPrice").val(ui.item.price);

        }

    });


    $("#UpdateOrderPurchaseItem_SKUName").autocomplete({
        appendTo: "#addItemUpdateOrderModal",
        source: function (request, response) {
            var request = {
                Name: request.term
            };
            $.ajax({
                url: 'https://localhost:7043/api/order/taker/GetSKUByName',
                data: JSON.stringify(request),
                type: "POST",
                contentType: 'application/json; charset=UTF-8',
                dataType: "json",
                success: function (data) {
                    console.log(data);
                    response($.map(data, function (sku) {
                        //console.log(sku);
                        if (sku != null) {
                            return {
                                label: sku.name,
                                value: sku.name,
                                id: sku.id,
                                price: sku.unitPrice

                            };
                        } else {
                            return {
                                label: '',
                                value: '',
                                id: 0,
                                price: 0

                            };
                        }

                    }));
                },

                error: function (xhr, textStatus, errorThrown) {
                    console.error('Error in fetching autocomplete data: ', textStatus);
                }
            });
        },
        select: function (event, ui) {
            $("#UpdateOrderPurchaseItem_SKUId").val(ui.item.id);
            $("#UpdateOrderPurchaseItem_Quantity").val(1);

            $("#UpdateOrderPurchaseItem_Price").val(ui.item.price);
            $("#UpdateOrderPurchaseItem_UnitPrice").val(ui.item.price);

        }

    });
});

$(function () {
    var date = new Date();
    var minDate = new Date(date.getFullYear(), date.getMonth(), date.getDate()+2);
    $('#Order_DeliveryDate').datepicker({
        dateFormat: 'yy-mm-dd',
        minDate: minDate,
    });

});
$(function () {
    var date = new Date();
    var minDate = new Date(date.getFullYear(), date.getMonth(), date.getDate() + 2);
    $('#UpdateDeliveryDate').datepicker({
        dateFormat: 'yy-mm-dd',
        minDate: minDate,
    });

});
