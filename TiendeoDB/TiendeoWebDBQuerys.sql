SELECT S.*
FROM master.dbo.Servicio S (NOLOCK)
INNER JOIN master.dbo.TipoServicio TS (NOLOCK) ON TS.IdTipoServicio = S.IdTipoServicio AND TS.nombre = 'cajero'

SELECT T.*
FROM master.dbo.Tienda T (NOLOCK)
INNER JOIN master.dbo.Local L (NOLOCK) ON L.IdLocal = T.IdLocal
INNER JOIN master.dbo.Negocio N (NOLOCK) ON N.IdNegocio = L.IdNegocio AND N.Nombre = 'Carrefour'

SELECT TOP 2 T.*
FROM master.dbo.Tienda T (NOLOCK)
INNER JOIN master.dbo.Local L (NOLOCK) ON L.IdLocal = T.IdLocal
INNER JOIN master.dbo.Negocio N (NOLOCK) ON N.IdNegocio = L.IdNegocio AND N.Nombre = 'Lidl'
INNER JOIN master.dbo.Ciudad C (NOLOCK) ON C.IdCiudad = L.IdCiudad AND C.Nombre = 'Barcelona'
ORDER BY T.Rate ASC