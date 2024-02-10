
create table rol (
                     idRol int primary key identity ,
                     descripcion varchar(50),
                     fechaRegistro datetime default getdate()
)

create table permiso (
                         idPermiso int primary key identity ,
                         idRol int references rol(idRol),
                         nombreMenu varchar(100),
                         fechaRegistro datetime default getdate()
)

create table proveedor (
                           idProveedor int primary key identity ,
                           documento varchar(50),
                           razonSocial varchar(50),
                           correo varchar(100),
                           telefono char(10),
                           estado bit,
                           fechaRegistro datetime default getdate()
)

create table cliente (
                         idCliente int primary key identity ,
                         documento varchar(50),
                         nombreCompleto varchar(50),
                         correo varchar(100),
                         telefono char(10),
                         estado bit,
                         fechaRegistro datetime default getdate()
)

create table usuario (
                         idUsuario int primary key identity ,
                         documento varchar(50),
                         nombreCompleto varchar(50),
                         correo varchar(100),
                         clave varchar(50),
                         idRol int references rol(idRol),
                         estado bit,
                         fechaRegistro datetime default getdate()
)

create table categoria (
                           idCategoria int primary key identity ,
                           descrpcion varchar(100),
                           estado bit,
                           fechaRegistro datetime default getdate()
)

create table producto (
                          idProducto int primary key identity ,
                          idCategoria int references categoria(idCategoria),
                          codigo varchar(50),
                          nombre varchar(50),
                          descrpcion varchar(100),
                          stock int not null default 0,
                          precioCompra decimal(10,2) default 0,
                          precioVenta decimal(10,2) default 0,
                          estado bit,
                          fechaRegistro datetime default getdate()
)

create table compra (
                        idCompra int primary key identity ,
                        idUsuario int references usuario(idUsuario),
                        idProveedor int references proveedor(idProveedor),
                        documento varchar(50),
                        tipoDocumento varchar(50),
                        numeroDocumento varchar(50),
                        montoTotal decimal(10,2),
                        fechaRegistro datetime default getdate()
)

create table detalle_compra(
                               idDetalleCompra int primary key identity ,
                               idCompra int references compra(idCompra),
                               idProducto int references producto(idProducto),
                               precioCompra decimal(10,2) default 0,
                               precioVenta decimal(10,2) default 0,
                               cantidad int,
                               montoTotal decimal(10,2),
                               fechaRegistro datetime default getdate()
)

create table venta (
                       idVenta int primary key identity ,
                       idUsuario int references usuario(idUsuario),
                       tipoDocumento varchar(50),
                       numeroDocumento varchar(50),
                       documentoCliente varchar(50),
                       nombreCliente varchar(50),
                       montoPago decimal(10,2),
                       montoCambio decimal(10,2),
                       montoTotal decimal(10,2),
                       fechaRegistro datetime default getdate()
)

create table detalle_venta (
                               idDetalleVenta int primary key identity ,
                               idVenta int references venta(idVenta),
                               idProducto int references producto(idProducto),
                               precioVenta decimal(10,2),
                               cantidad int,
                               subTotal decimal(10,2),
                               fechaRegistro datetime default getdate()
)