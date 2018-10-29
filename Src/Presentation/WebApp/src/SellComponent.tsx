import * as React from 'react';

export interface ISellComponentProps {
    sell: any;
}

export default class SellComponent extends React.Component<ISellComponentProps> {
  public render() {

    const { sell } = this.props;

    return (
      <div>
        <h3>Factura: {sell.invoiceId}</h3>
        <p><b>Fecha Orden:</b> {new Date(sell.orderDate).toDateString()}</p>
        <p><b>Producto:</b> {sell.product.name}</p>
        <p><b>Precio Unidad:</b> ${sell.product.unitPrice}</p>
        <p><b>Cantidad:</b> {sell.quantity}</p>
        <p><b>Total:</b> {sell.totalPrice}</p>
        <p><b>Lugar Despacho:</b> {sell.dispatchPlace}</p>
        <hr />
      </div>
    );
  }
}