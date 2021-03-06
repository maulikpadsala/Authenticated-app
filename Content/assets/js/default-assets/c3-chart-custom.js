! function(e) {
    "use strict";
    var t = function() {};
    t.prototype.init = function() {
        c3.generate({
            bindto: "#chart",
            data: {
                columns: [
                    ["Desktops", 35, 20, 50, 40, 60, 50],
                    ["Tablets", 200, 130, 90, 240, 130, 220],
                    ["Mobiles", 300, 200, 160, 400, 250, 250]
                ],
                type: "bar",
                colors: {
                    Desktops: "#dcdcdc",
                    Tablets: "#4ac6ec",
                    Mobiles: "#727cf5"
                }
            }
        }), c3.generate({
            bindto: "#combine-chart",
            data: {
                columns: [
                    ["Desktops", 40, 20, 50, 40, 60, 50],
                    ["Tablets", 200, 130, 90, 240, 130, 220],
                    ["Mobiles", 300, 200, 160, 400, 250, 250],
                    ["Watch", 200, 130, 90, 240, 130, 220],
                    ["iPad", 130, 120, 150, 140, 160, 150]
                ],
                types: {
                    Desktops: "bar",
                    Tablets: "bar",
                    Mobiles: "spline",
                    Watch: "line",
                    iPad: "bar"
                },
                colors: {
                    Desktops: "#dcdcdc",
                    Tablets: "#4ac6ec",
                    Mobiles: "#36404a",
                    Watch: "#fb6d9d",
                    iPad: "#727cf5"
                },
                groups: [
                    ["Desktops", "Tablets"]
                ]
            },
            axis: {
                x: {
                    type: "categorized"
                }
            }
        }), c3.generate({
            bindto: "#roated-chart",
            data: {
                columns: [
                    ["Desktops", 70, 200, 100, 400, 150, 250],
                    ["Tablets", 50, 20, 10, 40, 15, 25]
                ],
                types: {
                    Desktops: "bar"
                },
                colors: {
                    Desktops: "#727cf5",
                    Tablets: "#4ac6ec"
                }
            },
            axis: {
                rotated: !0,
                x: {
                    type: "categorized"
                }
            }
        }), c3.generate({
            bindto: "#chart-stacked",
            data: {
                columns: [
                    ["Desktops", 30, 20, 50, 40, 60, 50],
                    ["Tablets", 200, 130, 90, 240, 130, 220]
                ],
                types: {
                    Desktops: "area-spline",
                    Tablets: "area-spline"
                },
                colors: {
                    Desktops: "#727cf5",
                    Tablets: "#4ac6ec"
                }
            }
        }), c3.generate({
            bindto: "#donut-chart",
            data: {
                columns: [
                    ["Desktops", 46],
                    ["Tablets", 24],
                    ["Mobiles", 30]
                ],
                type: "donut"
            },
            donut: {
                title: "Sales Analytics",
                width: 15,
                label: {
                    show: !1
                }
            },
            color: {
                pattern: ["#f4f8fb", "#4ac6ec", "#727cf5"]
            }
        }), c3.generate({
            bindto: "#pie-chart",
            data: {
                columns: [
                    ["iPhone", 46],
                    ["MI", 24],
                    ["Samsung", 30]
                ],
                type: "pie"
            },
            color: {
                pattern: ["#f4f8fb", "#4ac6ec", "#727cf5"]
            },
            pie: {
                label: {
                    show: !1
                }
            }
        }), c3.generate({
            bindto: "#line-regions",
            data: {
                columns: [
                    ["Desktops", 30, 200, 100, 400, 150, 250],
                    ["Tablets", 50, 20, 10, 40, 15, 25]
                ],
                regions: {
                    Desktops: [{
                        start: 1,
                        end: 2,
                        style: "dashed"
                    }, {
                        start: 3
                    }],
                    Tablets: [{
                        end: 3
                    }]
                },
                colors: {
                    Desktops: "#4ac6ec",
                    Tablets: "#fb6d9d"
                }
            }
        }), c3.generate({
            bindto: "#scatter-plot",
            data: {
                xs: {
                    Setosa: "setosa_x",
                    Versicolor: "versicolor_x"
                },
                columns: [
                    ["setosa_x", 3.5, 3, 3.2, 3.1, 3.6, 3.9, 3.4, 3.4, 2.9, 3.1, 3.7, 3.4, 3, 3, 4, 4.4, 3.9, 3.5, 3.8, 3.8, 3.4, 3.7, 3.6, 3.3, 3.4, 3, 3.4, 3.5, 3.4, 3.2, 3.1, 3.4, 4.1, 4.2, 3.1, 3.2, 3.5, 3.6, 3, 3.4, 3.5, 2.3, 3.2, 3.5, 3.8, 3, 3.8, 3.2, 3.7, 3.3],
                    ["versicolor_x", 3.2, 3.2, 3.1, 2.3, 2.8, 2.8, 3.3, 2.4, 2.9, 2.7, 2, 3, 2.2, 2.9, 2.9, 3.1, 3, 2.7, 2.2, 2.5, 3.2, 2.8, 2.5, 2.8, 2.9, 3, 2.8, 3, 2.9, 2.6, 2.4, 2.4, 2.7, 2.7, 3, 3.4, 3.1, 2.3, 3, 2.5, 2.6, 3, 2.6, 2.3, 2.7, 3, 2.9, 2.9, 2.5, 2.8],
                    ["Setosa", .2, .2, .2, .2, .2, .4, .3, .2, .2, .1, .2, .2, .1, .1, .2, .4, .4, .3, .3, .3, .2, .4, .2, .5, .2, .2, .4, .2, .2, .2, .2, .4, .1, .2, .2, .2, .2, .1, .2, .2, .3, .3, .2, .6, .4, .3, .2, .2, .2, .2],
                    ["Versicolor", 1.4, 1.5, 1.5, 1.3, 1.5, 1.3, 1.6, 1, 1.3, 1.4, 1, 1.5, 1, 1.4, 1.3, 1.4, 1.5, 1, 1.5, 1.1, 1.8, 1.3, 1.5, 1.2, 1.3, 1.4, 1.4, 1.7, 1.5, 1, 1.1, 1, 1.2, 1.6, 1.5, 1.6, 1.5, 1.3, 1.3, 1.3, 1.2, 1.4, 1.2, 1, 1.3, 1.2, 1.3, 1.3, 1.1, 1.3]
                ],
                type: "scatter"
            },
            color: {
                pattern: ["#4ac6ec", "#727cf5", "#4ac6ec", "#727cf5"]
            },
            axis: {
                x: {
                    label: "Sepal.Width",
                    tick: {
                        fit: !1
                    }
                },
                y: {
                    label: "Petal.Width"
                }
            }
        })
    }, e.ChartC3 = new t, e.ChartC3.Constructor = t
}(window.jQuery),
function(e) {
    "use strict";
    window.jQuery.ChartC3.init()
}();