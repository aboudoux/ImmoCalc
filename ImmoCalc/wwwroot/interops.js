var RefresherComponent = RefresherComponent || {};
RefresherComponent.refresh = function (element, dotNet) {
    element.addEventListener('ionRefresh', function () { dotNet.invokeMethodAsync("OnRefresh") });
};

RefresherComponent.complete = function (element) {
    element.complete();
};