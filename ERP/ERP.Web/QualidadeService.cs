
namespace ERP.Web
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
    using ErpQualidadeModel;


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
        // To support paging you will need to add ordering to the 'SatisfacaoClienteSets' query.
        public IQueryable<SatisfacaoClienteSet> GetSatisfacaoClienteSets()
        {
            return this.ObjectContext.SatisfacaoClienteSets;
        }

        public void InsertSatisfacaoClienteSet(SatisfacaoClienteSet satisfacaoClienteSet)
        {
            if ((satisfacaoClienteSet.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(satisfacaoClienteSet, EntityState.Added);
            }
            else
            {
                this.ObjectContext.SatisfacaoClienteSets.AddObject(satisfacaoClienteSet);
            }
        }

        public void UpdateSatisfacaoClienteSet(SatisfacaoClienteSet currentSatisfacaoClienteSet)
        {
            this.ObjectContext.SatisfacaoClienteSets.AttachAsModified(currentSatisfacaoClienteSet, this.ChangeSet.GetOriginal(currentSatisfacaoClienteSet));
        }

        public void DeleteSatisfacaoClienteSet(SatisfacaoClienteSet satisfacaoClienteSet)
        {
            if ((satisfacaoClienteSet.EntityState == EntityState.Detached))
            {
                this.ObjectContext.SatisfacaoClienteSets.Attach(satisfacaoClienteSet);
            }
            this.ObjectContext.SatisfacaoClienteSets.DeleteObject(satisfacaoClienteSet);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'SatisfacaoFuncionarioSets' query.
        public IQueryable<SatisfacaoFuncionarioSet> GetSatisfacaoFuncionarioSets()
        {
            return this.ObjectContext.SatisfacaoFuncionarioSets;
        }

        public void InsertSatisfacaoFuncionarioSet(SatisfacaoFuncionarioSet satisfacaoFuncionarioSet)
        {
            if ((satisfacaoFuncionarioSet.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(satisfacaoFuncionarioSet, EntityState.Added);
            }
            else
            {
                this.ObjectContext.SatisfacaoFuncionarioSets.AddObject(satisfacaoFuncionarioSet);
            }
        }

        public void UpdateSatisfacaoFuncionarioSet(SatisfacaoFuncionarioSet currentSatisfacaoFuncionarioSet)
        {
            this.ObjectContext.SatisfacaoFuncionarioSets.AttachAsModified(currentSatisfacaoFuncionarioSet, this.ChangeSet.GetOriginal(currentSatisfacaoFuncionarioSet));
        }

        public void DeleteSatisfacaoFuncionarioSet(SatisfacaoFuncionarioSet satisfacaoFuncionarioSet)
        {
            if ((satisfacaoFuncionarioSet.EntityState == EntityState.Detached))
            {
                this.ObjectContext.SatisfacaoFuncionarioSets.Attach(satisfacaoFuncionarioSet);
            }
            this.ObjectContext.SatisfacaoFuncionarioSets.DeleteObject(satisfacaoFuncionarioSet);
        }
    }
}


