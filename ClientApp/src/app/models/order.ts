import { formatDate } from "@angular/common";

export class Order {
    id: number;
    createDate: Date;
    agentName: string;
    statusId: number;
    status: string;

    constructor(id: number, createDate: Date, agentName: string, statusId: number, status: string) {
        this.id = id;
        this.createDate = createDate;
        this.agentName = agentName;
        this.statusId = statusId;
        this.status = status;
      }

      public static mapFromServerObject(jsonObject: Order): Order {
        return new Order(jsonObject.id, jsonObject.createDate, jsonObject.agentName, jsonObject.statusId, jsonObject.status);
      }

      public getOrderDate(): string {
        return formatDate(this.createDate, 'dd.MM.yy HH:mm', 'ru-RU')
      }
}
