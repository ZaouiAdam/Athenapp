/*************************** Passage des étapes TNT en UPS ****************************/
USE DelivApp
GO

UPDATE TB_ETAPE
SET Texte = 'Transporteur UPS à notre compte si colis < 25kg ou Dachser si colis > 25 kg'
WHERE Texte like '%Transporteur UPS à notre compte si colis < 25kg ou Dachser si colis > 25 kg%'
AND IdIncoterm = (SELECT Id FROM TB_INCOTERM WHERE Nom = 'DAP');

UPDATE TB_ETAPE
SET Texte = 'Si colis< 25Kgs Utilisez transporteur UPS à notre compte'
WHERE Texte like '%Si colis< 25Kgs Utilisez transporteur TNT à notre compte%'
AND IdIncoterm = (SELECT Id FROM TB_INCOTERM WHERE Nom = 'DAP');