﻿CREATE view [web].[VWCXP_012]
as
SELECT dbo.cp_retencion.IdEmpresa, dbo.cp_retencion.IdRetencion, dbo.cp_retencion.CodDocumentoTipo, dbo.cp_retencion.serie1, dbo.cp_retencion.serie2, dbo.cp_retencion.NumRetencion, dbo.cp_retencion.NAutorizacion, 
                  dbo.cp_retencion.Fecha_Autorizacion, dbo.cp_retencion.fecha, dbo.cp_retencion.observacion, dbo.cp_retencion.re_Tiene_RTiva, dbo.cp_retencion.re_Tiene_RFuente, 
                  dbo.cp_orden_giro.co_serie + '-' + dbo.cp_orden_giro.co_factura AS co_factura, dbo.cp_orden_giro.co_FechaFactura, CASE WHEN dbo.cp_retencion_det.re_tipoRet = 'RTF' THEN 'RENTA' ELSE 'IVA' END AS re_tipoRet, 
                  dbo.cp_retencion_det.re_baseRetencion, dbo.cp_retencion_det.IdCodigo_SRI, dbo.cp_retencion_det.re_Codigo_impuesto, dbo.cp_retencion_det.re_Porcen_retencion, dbo.cp_retencion_det.re_valor_retencion, 
                  dbo.cp_codigo_SRI.co_descripcion, dbo.cp_proveedor.pr_direccion, dbo.cp_TipoDocumento.Descripcion, dbo.tb_persona.pe_cedulaRuc, dbo.tb_persona.pe_nombreCompleto
FROM     dbo.cp_codigo_SRI INNER JOIN
                  dbo.cp_retencion INNER JOIN
                  dbo.cp_retencion_det ON dbo.cp_retencion.IdEmpresa = dbo.cp_retencion_det.IdEmpresa AND dbo.cp_retencion.IdRetencion = dbo.cp_retencion_det.IdRetencion ON 
                  dbo.cp_codigo_SRI.IdCodigo_SRI = dbo.cp_retencion_det.IdCodigo_SRI INNER JOIN
                  dbo.cp_orden_giro ON dbo.cp_retencion.IdEmpresa_Ogiro = dbo.cp_orden_giro.IdEmpresa AND dbo.cp_retencion.IdCbteCble_Ogiro = dbo.cp_orden_giro.IdCbteCble_Ogiro AND 
                  dbo.cp_retencion.IdTipoCbte_Ogiro = dbo.cp_orden_giro.IdTipoCbte_Ogiro INNER JOIN
                  dbo.tb_persona INNER JOIN
                  dbo.cp_proveedor ON dbo.tb_persona.IdPersona = dbo.cp_proveedor.IdPersona ON dbo.cp_orden_giro.IdEmpresa = dbo.cp_proveedor.IdEmpresa AND dbo.cp_orden_giro.IdProveedor = dbo.cp_proveedor.IdProveedor INNER JOIN
                  dbo.cp_TipoDocumento ON dbo.cp_orden_giro.IdOrden_giro_Tipo = dbo.cp_TipoDocumento.CodTipoDocumento
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'web', @level1type = N'VIEW', @level1name = N'VWCXP_012';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'          End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 26
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 2115
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'web', @level1type = N'VIEW', @level1name = N'VWCXP_012';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[17] 4[19] 2[22] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "cp_codigo_SRI"
            Begin Extent = 
               Top = 109
               Left = 89
               Bottom = 367
               Right = 277
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "cp_retencion"
            Begin Extent = 
               Top = 396
               Left = 1016
               Bottom = 751
               Right = 1214
            End
            DisplayFlags = 280
            TopColumn = 13
         End
         Begin Table = "cp_retencion_det"
            Begin Extent = 
               Top = 405
               Left = 431
               Bottom = 809
               Right = 629
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "cp_orden_giro"
            Begin Extent = 
               Top = 19
               Left = 406
               Bottom = 377
               Right = 666
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tb_persona"
            Begin Extent = 
               Top = 5
               Left = 782
               Bottom = 381
               Right = 1014
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "cp_proveedor"
            Begin Extent = 
               Top = 20
               Left = 415
               Bottom = 332
               Right = 647
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "cp_TipoDocumento"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 179
               Right = 307
  ', @level0type = N'SCHEMA', @level0name = N'web', @level1type = N'VIEW', @level1name = N'VWCXP_012';

