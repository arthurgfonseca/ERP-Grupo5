
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
    using ErpAdministracaoModel;


    // Implements application logic using the erp_administracaoEntities context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class AdministracaoService : LinqToEntitiesDomainService<erp_administracaoEntities>
    {

        // Conêvnios de Planos de Saúde
        public IQueryable<ConvenioPlanoSaudeSet> GetConvenioPlanoSaudeSet()
        {
            return this.ObjectContext.ConvenioPlanoSaudeSet.OrderBy(e => e.codigo);
        }

        public void InsertConvenioPlanoSaudeSet(ConvenioPlanoSaudeSet convenioPlanoSaudeSet)
        {
            if ((convenioPlanoSaudeSet.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(convenioPlanoSaudeSet, EntityState.Added);
            }
            else
            {
                this.ObjectContext.ConvenioPlanoSaudeSet.AddObject(convenioPlanoSaudeSet);
            }
        }

        public void UpdateConvenioPlanoSaudeSet(ConvenioPlanoSaudeSet currentConvenioPlanoSaudeSet)
        {
            this.ObjectContext.ConvenioPlanoSaudeSet.AttachAsModified(currentConvenioPlanoSaudeSet, this.ChangeSet.GetOriginal(currentConvenioPlanoSaudeSet));
        }

        public void DeleteConvenioPlanoSaudeSet(ConvenioPlanoSaudeSet convenioPlanoSaudeSet)
        {
            if ((convenioPlanoSaudeSet.EntityState == EntityState.Detached))
            {
                this.ObjectContext.ConvenioPlanoSaudeSet.Attach(convenioPlanoSaudeSet);
            }
            this.ObjectContext.ConvenioPlanoSaudeSet.DeleteObject(convenioPlanoSaudeSet);
        }

        // Convênio - Servicos
        public IQueryable<ConvenioServicoSet> GetConvenioServicoSet()
        {
            return this.ObjectContext.ConvenioServicoSet.OrderBy(e => e.ServicoMedicoSet_codigo);
        }

        public IQueryable<ConvenioServicoSet> GetConvenioServicoSet_CodigoConvenio(int codigoConvenio)
        {
            return this.ObjectContext.ConvenioServicoSet.Where(e => e.ConvenioPlanoSaude_codigo == codigoConvenio).OrderBy(e => e.ServicoMedicoSet_codigo);
        }

        public void InsertConvenioServicoSet(ConvenioServicoSet convenioServicoSet)
        {
            if ((convenioServicoSet.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(convenioServicoSet, EntityState.Added);
            }
            else
            {
                this.ObjectContext.ConvenioServicoSet.AddObject(convenioServicoSet);
            }
        }

        public void UpdateConvenioServicoSet(ConvenioServicoSet currentConvenioServicoSet)
        {
            this.ObjectContext.ConvenioServicoSet.AttachAsModified(currentConvenioServicoSet, this.ChangeSet.GetOriginal(currentConvenioServicoSet));
        }

        public void DeleteConvenioServicoSet(ConvenioServicoSet convenioServicoSet)
        {
            if ((convenioServicoSet.EntityState == EntityState.Detached))
            {
                this.ObjectContext.ConvenioServicoSet.Attach(convenioServicoSet);
            }
            this.ObjectContext.ConvenioServicoSet.DeleteObject(convenioServicoSet);
        }

        // Serviços Médicos
        public IQueryable<ServicoMedicoSet> GetServicoMedicoSet()
        {
            return this.ObjectContext.ServicoMedicoSet.OrderBy(e => e.codigo);
        }

        public void InsertServicoMedicoSet(ServicoMedicoSet servicoMedicoSet)
        {
            if ((servicoMedicoSet.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(servicoMedicoSet, EntityState.Added);
            }
            else
            {
                this.ObjectContext.ServicoMedicoSet.AddObject(servicoMedicoSet);
            }
        }

        public void UpdateServicoMedicoSet(ServicoMedicoSet currentServicoMedicoSet)
        {
            this.ObjectContext.ServicoMedicoSet.AttachAsModified(currentServicoMedicoSet, this.ChangeSet.GetOriginal(currentServicoMedicoSet));
        }

        public void DeleteServicoMedicoSet(ServicoMedicoSet servicoMedicoSet)
        {
            if ((servicoMedicoSet.EntityState == EntityState.Detached))
            {
                this.ObjectContext.ServicoMedicoSet.Attach(servicoMedicoSet);
            }
            this.ObjectContext.ServicoMedicoSet.DeleteObject(servicoMedicoSet);
        }
    }
}


