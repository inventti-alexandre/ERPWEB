﻿CREATE TABLE [dbo].[ro_empleado] (
    [IdEmpresa]                            INT           NOT NULL,
    [IdEmpleado]                           NUMERIC (18)  NOT NULL,
    [IdEmpleado_Supervisor]                NUMERIC (18)  NULL,
    [IdPersona]                            NUMERIC (18)  NOT NULL,
    [IdSucursal]                           INT           NOT NULL,
    [IdTipoEmpleado]                       VARCHAR (10)  NOT NULL,
    [em_codigo]                            VARCHAR (50)  NULL,
    [Codigo_Biometrico]                    VARCHAR (50)  NULL,
    [em_lugarNacimiento]                   VARCHAR (500) NOT NULL,
    [em_CarnetIees]                        VARCHAR (20)  NULL,
    [em_cedulaMil]                         VARCHAR (20)  NULL,
    [em_fechaSalida]                       DATETIME      NULL,
    [em_fechaIngaRol]                      DATETIME      NULL,
    [em_tipoCta]                           VARCHAR (25)  NULL,
    [em_NumCta]                            VARCHAR (20)  NULL,
    [em_estado]                            VARCHAR (1)   NOT NULL,
    [IdCodSectorial]                       INT           NULL,
    [IdDepartamento]                       INT           NOT NULL,
    [IdTipoSangre]                         VARCHAR (10)  NULL,
    [IdCargo]                              INT           NULL,
    [IdCtaCble_Emplea]                     VARCHAR (20)  NULL,
    [IdCiudad]                             VARCHAR (25)  NULL,
    [em_mail]                              VARCHAR (50)  NULL,
    [IdTipoLicencia]                       VARCHAR (10)  NULL,
    [IdBanco]                              INT           NULL,
    [IdArea]                               INT           NULL,
    [IdDivision]                           INT           NULL,
    [IdUsuario]                            VARCHAR (20)  NULL,
    [Fecha_Transaccion]                    DATETIME      NULL,
    [IdUsuarioUltModi]                     VARCHAR (20)  NULL,
    [Fecha_UltMod]                         DATETIME      NULL,
    [IdUsuarioUltAnu]                      VARCHAR (20)  NULL,
    [Fecha_UltAnu]                         DATETIME      NULL,
    [MotivoAnulacion]                      VARCHAR (100) NULL,
    [por_discapacidad]                     FLOAT (53)    NOT NULL,
    [carnet_conadis]                       VARCHAR (50)  NULL,
    [talla_pant]                           FLOAT (53)    NULL,
    [talla_camisa]                         VARCHAR (50)  NULL,
    [talla_zapato]                         FLOAT (53)    NULL,
    [em_status]                            VARCHAR (10)  NULL,
    [IdCondicionDiscapacidadSRI]           VARCHAR (10)  NULL,
    [IdTipoIdentDiscapacitadoSustitutoSRI] VARCHAR (10)  NULL,
    [IdentDiscapacitadoSustitutoSRI]       VARCHAR (50)  NULL,
    [IdAplicaConvenioDobleImposicionSRI]   VARCHAR (10)  NULL,
    [IdTipoResidenciaSRI]                  VARCHAR (10)  NULL,
    [IdTipoSistemaSalarioNetoSRI]          VARCHAR (10)  NULL,
    [es_AcreditaHorasExtras]               BIT           NOT NULL,
    [IdTipoAnticipo]                       VARCHAR (10)  NULL,
    [ValorAnticipo]                        FLOAT (53)    NULL,
    [CodigoSectorial]                      VARCHAR (25)  NULL,
    [em_AnticipoSueldo]                    FLOAT (53)    NULL,
    [Marca_Biometrico]                     BIT           NOT NULL,
    [IdHorario]                            INT           NULL,
    [Tiene_ingresos_compartidos]           BIT           NOT NULL,
    [Pago_por_horas]                       BIT           NOT NULL,
    [Valor_maximo_horas_vesp]              FLOAT (53)    NULL,
    [Valor_maximo_horas_mat]               FLOAT (53)    NULL,
    [Valor_horas_vespertina]               FLOAT (53)    NULL,
    [Valor_horas_matutino]                 FLOAT (53)    NULL,
    [Valor_horas_brigada]                  FLOAT (53)    NULL,
    [Valor_hora_adicionales]               FLOAT (53)    NULL,
    [Valor_hora_control_salida]            FLOAT (53)    NULL,
    [GozaMasDeQuinceDiasVaciones]          BIT           NOT NULL,
    [DiasVacaciones]                       FLOAT (53)    NOT NULL,
    [IdEmpleadoPAdre]                      NUMERIC (18)  NULL,
    [CodCatalogo_Ubicacion]                VARCHAR (10)  NULL,
    [IdCtaCble_x_pagar_empleado]           VARCHAR (20)  NULL,
    CONSTRAINT [PK_ro_empleado] PRIMARY KEY CLUSTERED ([IdEmpresa] ASC, [IdEmpleado] ASC),
    CONSTRAINT [FK_ro_empleado_ct_plancta] FOREIGN KEY ([IdEmpresa], [IdCtaCble_Emplea]) REFERENCES [dbo].[ct_plancta] ([IdEmpresa], [IdCtaCble]),
    CONSTRAINT [FK_ro_empleado_ct_plancta1] FOREIGN KEY ([IdEmpresa], [IdCtaCble_x_pagar_empleado]) REFERENCES [dbo].[ct_plancta] ([IdEmpresa], [IdCtaCble]),
    CONSTRAINT [FK_ro_empleado_ro_Cargo] FOREIGN KEY ([IdEmpresa], [IdCargo]) REFERENCES [dbo].[ro_cargo] ([IdEmpresa], [IdCargo]),
    CONSTRAINT [FK_ro_empleado_ro_Catalogo] FOREIGN KEY ([IdTipoEmpleado]) REFERENCES [dbo].[ro_catalogo] ([CodCatalogo]),
    CONSTRAINT [FK_ro_empleado_ro_Catalogo1] FOREIGN KEY ([IdTipoSangre]) REFERENCES [dbo].[ro_catalogo] ([CodCatalogo]),
    CONSTRAINT [FK_ro_empleado_ro_Catalogo2] FOREIGN KEY ([IdTipoLicencia]) REFERENCES [dbo].[ro_catalogo] ([CodCatalogo]),
    CONSTRAINT [FK_ro_empleado_ro_Catalogo3] FOREIGN KEY ([IdTipoLicencia]) REFERENCES [dbo].[ro_catalogo] ([CodCatalogo]),
    CONSTRAINT [FK_ro_empleado_ro_catalogo4] FOREIGN KEY ([CodCatalogo_Ubicacion]) REFERENCES [dbo].[ro_catalogo] ([CodCatalogo]),
    CONSTRAINT [FK_ro_empleado_ro_Departamento] FOREIGN KEY ([IdEmpresa], [IdDepartamento]) REFERENCES [dbo].[ro_Departamento] ([IdEmpresa], [IdDepartamento]),
    CONSTRAINT [FK_ro_empleado_ro_Division] FOREIGN KEY ([IdEmpresa], [IdDivision]) REFERENCES [dbo].[ro_Division] ([IdEmpresa], [IdDivision]),
    CONSTRAINT [FK_ro_empleado_ro_empleado] FOREIGN KEY ([IdEmpresa], [IdEmpleado_Supervisor]) REFERENCES [dbo].[ro_empleado] ([IdEmpresa], [IdEmpleado]),
    CONSTRAINT [FK_ro_empleado_ro_empleado1] FOREIGN KEY ([IdEmpresa], [IdEmpleadoPAdre]) REFERENCES [dbo].[ro_empleado] ([IdEmpresa], [IdEmpleado]),
    CONSTRAINT [FK_ro_empleado_tb_banco] FOREIGN KEY ([IdBanco]) REFERENCES [dbo].[tb_banco] ([IdBanco]),
    CONSTRAINT [FK_ro_empleado_tb_ciudad] FOREIGN KEY ([IdCiudad]) REFERENCES [dbo].[tb_ciudad] ([IdCiudad]),
    CONSTRAINT [FK_ro_empleado_tb_persona] FOREIGN KEY ([IdPersona]) REFERENCES [dbo].[tb_persona] ([IdPersona]),
    CONSTRAINT [FK_ro_empleado_tb_sucursal] FOREIGN KEY ([IdEmpresa], [IdSucursal]) REFERENCES [dbo].[tb_sucursal] ([IdEmpresa], [IdSucursal])
);

















