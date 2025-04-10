using Business.BusinessObjects;
using Business.BusinessObjects.CodeList;
using Business.Parsers;
using PC_GUI.ViewModels.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_GUI.Mapping
{
	internal static partial class Mapper
	{

		internal static class SessionMapper
		{
			internal static SessionBo SessionNewViewModelToSessionBo(SessionNewViewModel model)
			{
				var sessionBo = new SessionBo();
				/****************************
				 * 
				 *   Session
				 * 
				 ***************************/
				sessionBo.Name = model.SessionName;
				sessionBo.Description = model.SessionDescription;
				sessionBo.Note = model.SessionNote;
				sessionBo.DateStart = model.SessionDateStart;
				sessionBo.DateEnd = model.SessionDateEnd;
				sessionBo.PlaceId = model.SelectedPlaceItem.DbId;
				sessionBo.IsUsed = true;


				/****************************
				 * 
				 *   Series
				 * 
				 ***************************/
				var seriesBo = new SeriesBo();
				var seriesSelected = model.SelectedSeries;
				seriesBo.Name = seriesSelected.Name;
				seriesBo.DbId = seriesSelected.DbId;
				if (model.IsNewSeries)
				{
					seriesBo = new SeriesBo();
					seriesBo.Name = model.SeriesName;
				}

				sessionBo.SeriesBoList.Add(seriesBo);

				/****************************
				 * 
				 *   Disciplines
				 * 
				 ***************************/
				var disciplineBo = new DisciplineBo();
				disciplineBo.Name = model.DisciplineName;
				disciplineBo.CDisciplineTypeId = model.SelectedCDisciplineItem.DbId;
				disciplineBo.TargetId = model.SelectedTargetItem.DbId;
				disciplineBo.CShootingPositionId = model.SelectedCShootingPositionItem.DbId;
				disciplineBo.Description = model.DisciplineDescription;
				disciplineBo.Note = model.DisciplineNote;
				disciplineBo.Range = model.Range;
				disciplineBo.RangeIsInMeters = model.RangeIsInMeters;
				disciplineBo.ScoreMax = NumberParser.StringToFloat(model.ScoreMax);
				disciplineBo.RoundsMax = NumberParser.StringToInt(model.RoundsMax);
				disciplineBo.Date = model.DisciplineDate;

				sessionBo.DisciplineBoList.Add(disciplineBo);


				return sessionBo;
			}


		}
	}
}
