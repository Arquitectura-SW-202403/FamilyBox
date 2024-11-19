type User = {
    usuarioId? : string;
    tipoDocumento? : string;
    nombre? : string;
    apellido? : string;
    email? : string;
    telefono? : string;
    password? : string;
    tipoUsuario? :  "Admin" | "Beneficiario" | "Afiliado" | "Normal";
    fechaRegistro? : Date;
    estado? : boolean;
}