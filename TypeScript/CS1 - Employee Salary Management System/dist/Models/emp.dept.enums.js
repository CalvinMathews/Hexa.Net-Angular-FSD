"use strict";
// Enums for Department and Ctegory
Object.defineProperty(exports, "__esModule", { value: true });
exports.empcat = exports.empdept = void 0;
var empdept;
(function (empdept) {
    empdept["HR"] = "HR";
    empdept["IT"] = "IT";
    empdept["Sales"] = "Sales";
})(empdept || (exports.empdept = empdept = {}));
var empcat;
(function (empcat) {
    empcat["High"] = "High Earner";
    empcat["Mid"] = "Mid Earner";
    empcat["Low"] = "Low Earner";
})(empcat || (exports.empcat = empcat = {}));
