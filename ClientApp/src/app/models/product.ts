export class Product {
    orderId: number;
    productId: number;
    productName: string;
    price: number;
    quantity: number;
    amount: number;

    constructor(orderId: number, productId: number, productName: string, price: number, quantity: number, amount: number) {
        this.orderId = orderId;
        this.productId = productId;
        this.productName = productName;
        this.price = price;
        this.quantity = quantity;
        this.amount = amount;
    }

    public static mapFromServerObject(jsonObject: Product): Product {
        return new Product(
            jsonObject.orderId,
            jsonObject.productId,
            jsonObject.productName,
            jsonObject.price,
            jsonObject.quantity,
            jsonObject.amount);
    }
}
