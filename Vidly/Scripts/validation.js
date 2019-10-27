$.validator.addMethod("validCustomer", function () {
    return vm.customerId && vm.customerId !== 0;
}, "Please select a valid customer.");

$.validator.addMethod("atLeastOneMovie", function () {
    return vm.movieIds.length > 0;
}, "Please select at least one movie.");