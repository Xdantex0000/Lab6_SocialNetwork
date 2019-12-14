import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
let AppAuthorization = class AppAuthorization {
    constructor(http) {
        this.http = http;
    }
    ngOnInit() {
        this.http.get('http://localhost:44394/api/values/1').subscribe((get_data) => this.data = get_data.toString());
    }
};
AppAuthorization = tslib_1.__decorate([
    Component({
        selector: 'registration',
        templateUrl: './registration.component.html',
        styleUrls: ['./registration.component.css']
    })
], AppAuthorization);
export { AppAuthorization };
//# sourceMappingURL=authorization.component.js.map