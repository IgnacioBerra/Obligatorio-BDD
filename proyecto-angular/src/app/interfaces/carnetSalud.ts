export interface CarnetSalud {
    CI: number;
    fechaEmision: Date;
    fechaVencimiento: Date;
    Comprobante: string; //o blob
    FuncId: number;
}