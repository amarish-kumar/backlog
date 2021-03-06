import { fetch } from "../utilities";
import { BrandOwner } from "./brand-owner.model";

export class BrandOwnerService {
    
    private static _instance: BrandOwnerService;

    public static get Instance() {
        this._instance = this._instance || new this();
        return this._instance;
    }

    public get() {
        return fetch({ url: "/api/brand-owner/get", authRequired: true });
    }

    public getById(id) {
        return fetch({ url: `/api/brand-owner/getbyid?id=${id}`, authRequired: true });
    }

    public add(entity) {
        return fetch({ url: `/api/brand-owner/add`, method: "POST", data: entity, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return fetch({ url: `/api/brand-owner/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }
    
}
