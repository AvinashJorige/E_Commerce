$(document).ready(function () {
    loadCategory();
});

function loadCategory() {
    try {
        var url = "/Admin/Admin_Category/GetCategoryAll";

        Common.Ajax('GET', url, null, 'json', function (res) {
            if (res) {
                //alert(JSON.stringify(res));
                var dataInfo = JSON.parse(res);
                var li_list_content = "";

                var completeList = "";
                var collectionList = "";

                $.each(dataInfo, function (index, value) {
                    if ((index + 1) % 5 == 0) {
                        completeList += "<div class='row'>" + collectionList + "</div>";
                        collectionList ="";
                    }
                    for (i = 0; i < 5; i++) {
                        li_list_content += "<li class='collection-item'><div><span class='item-name'>Alvin</span></div></li>";
                    }

                    collectionList += "<div class='containerList col s12 m3'><ul class='z-depth-2 collection with-header'>"
                        + "<li class='collection-header'><h5><span class='heade-title'>" + value.ct_Name + "</span><div class='icon-item z-depth-3 hvr-wobble-skew'><i class='fa fa-adn' aria-hidden='true'></i></div></h5></li>"
                            + li_list_content + "</ul></div>";

                    li_list_content = "";
                    if ((dataInfo.length - 1) == index) {
                        completeList += "<div class='row'>" + collectionList + "</div>";
                        collectionList = "";
                    }
                });
                $(".categoryList").html(completeList);
            }
            else {
                alert("Invalid login")
            }
        });

    } catch (e) {
        console.log("DASHBOARD|LOADCATEGORY|ERROR: ", e);
    }
}