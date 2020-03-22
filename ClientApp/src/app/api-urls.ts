export class ApiUrls {
    public static readonly apiUrl = 'Orders';

    public static readonly getOrders = `${ApiUrls.apiUrl}/GetAllOrders`;
    public static getOrderProducts(orderId: number): string {

        return `${ApiUrls.apiUrl}/GetOrderProducts/` + orderId.toString();
    } 
}
