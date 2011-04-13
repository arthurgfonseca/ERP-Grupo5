
namespace ERP.Web.Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using ERPQualidadeModel;


    // Implements application logic using the erp_qualidadeEntities context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class QualidadeService : LinqToEntitiesDomainService<erp_qualidadeEntities>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'SatisfacaoClienteSet' query.
        public IQueryable<SatisfacaoClienteSet> GetSatisfacaoClienteSet()
        {
            return this.ObjectContext.SatisfacaoClienteSet;
        }

        public void InsertSatisfacaoClienteSet(SatisfacaoClienteSet satisfacaoClienteSet)
        {
            if ((satisfacaoClienteSet.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(satisfacaoClienteSet, EntityState.Added);
            }
            else
            {
                this.ObjectContext.SatisfacaoClienteSet.AddObject(satisfacaoClienteSet);
            }
        }

        public void UpdateSatisfacaoClienteSet(SatisfacaoClienteSet currentSatisfacaoClienteSet)
        {
            this.ObjectContext.SatisfacaoClienteSet.AttachAsModified(currentSatisfacaoClienteSet, this.ChangeSet.GetOriginal(currentSatisfacaoClienteSet));
        }

        public void DeleteSatisfacaoClienteSet(SatisfacaoClienteSet satisfacaoClienteSet)
        {
            if ((satisfacaoClienteSet.EntityState == EntityState.Detached))
            {
                this.ObjectContext.SatisfacaoClienteSet.Attach(satisfacaoClienteSet);
            }
            this.ObjectContext.SatisfacaoClienteSet.DeleteObject(satisfacaoClienteSet);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'SatisfacaoFuncionarioSet' query.
        public IQueryable<SatisfacaoFuncionarioSet> GetSatisfacaoFuncionarioSet()
        {
            return this.ObjectContext.SatisfacaoFuncionarioSet;
        }

        public void InsertSatisfacaoFuncionarioSet(SatisfacaoFuncionarioSet satisfacaoFuncionarioSet)
        {
            if ((satisfacaoFuncionarioSet.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(satisfacaoFuncionarioSet, EntityState.Added);
            }
            else
            {
                this.ObjectContext.SatisfacaoFuncionarioSet.AddObject(satisfacaoFuncionarioSet);
            }
        }

        public void UpdateSatisfacaoFuncionarioSet(SatisfacaoFuncionarioSet currentSatisfacaoFuncionarioSet)
        {
            this.ObjectContext.SatisfacaoFuncionarioSet.AttachAsModified(currentSatisfacaoFuncionarioSet, this.ChangeSet.GetOriginal(currentSatisfacaoFuncionarioSet));
        }

        public void DeleteSatisfacaoFuncionarioSet(SatisfacaoFuncionarioSet satisfacaoFuncionarioSet)
        {
            if ((satisfacaoFuncionarioSet.EntityState == EntityState.Detached))
            {
                this.ObjectContext.SatisfacaoFuncionarioSet.Attach(satisfacaoFuncionarioSet);
            }
            this.ObjectContext.SatisfacaoFuncionarioSet.DeleteObject(satisfacaoFuncionarioSet);
        }
    }
}


