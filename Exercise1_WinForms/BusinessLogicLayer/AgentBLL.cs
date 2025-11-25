using System;
using System.Data;
using DataAccessLayer;
using Models;

namespace BusinessLogicLayer
{
    public class AgentBLL
    {
        private AgentDAO agentDAO;

        public AgentBLL()
        {
            agentDAO = new AgentDAO();
        }

        public DataTable GetAllAgents()
        {
            return agentDAO.GetAllAgents();
        }

        public DataTable GetActiveAgents()
        {
            return agentDAO.GetActiveAgents();
        }

        public Agent GetAgentById(int agentId)
        {
            if (agentId <= 0)
                throw new Exception("Invalid Agent ID");

            return agentDAO.GetAgentById(agentId);
        }

        public bool InsertAgent(Agent agent)
        {
            ValidateAgent(agent);
            return agentDAO.InsertAgent(agent);
        }

        public bool UpdateAgent(Agent agent)
        {
            if (agent.AgentID <= 0)
                throw new Exception("Invalid Agent ID");

            ValidateAgent(agent);
            return agentDAO.UpdateAgent(agent);
        }

        public bool DeleteAgent(int agentId)
        {
            if (agentId <= 0)
                throw new Exception("Invalid Agent ID");

            return agentDAO.DeleteAgent(agentId);
        }

        public DataTable SearchAgents(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return GetAllAgents();

            return agentDAO.SearchAgents(searchText);
        }

        public DataTable GetTopCustomers()
        {
            return agentDAO.GetTopCustomers();
        }

        public DataTable GetAgentsByItem(int itemId)
        {
            if (itemId <= 0)
                throw new Exception("Invalid Item ID");

            return agentDAO.GetAgentsByItem(itemId);
        }

        private void ValidateAgent(Agent agent)
        {
            if (string.IsNullOrWhiteSpace(agent.AgentName))
                throw new Exception("Agent name is required");

            if (!string.IsNullOrWhiteSpace(agent.Email))
            {
                if (!agent.Email.Contains("@"))
                    throw new Exception("Invalid email format");
            }
        }
    }
}
