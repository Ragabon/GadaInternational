namespace Gada.Infrastructure.Data.EntityFramework.Interests.InterestsMigrations
{
    using Gada.Interests.Entities;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Gada.Infrastructure.Data.EntityFramework.InterestsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Interests\InterestsMigrations";
        }

        protected override void Seed(Gada.Infrastructure.Data.EntityFramework.InterestsContext context)
        {
            var interestCategories = GenerateInterestCategories();
            var interests = GenerateInterests(interestCategories);
            //var discussionsInterests = GenerateDiscussionInterests();

            context.InterestCategories.AddRange(interestCategories);
            context.Interests.AddRange(interests);
            context.SaveChanges();
        }

        private List<InterestCategory> GenerateInterestCategories()
        {
            var categories = new List<InterestCategory>();
            categories.Add(InterestCategory.CreateInterestCategory("Environment"));
            categories.Add(InterestCategory.CreateInterestCategory("International Relations"));
            categories.Add(InterestCategory.CreateInterestCategory("Global Security"));
            categories.Add(InterestCategory.CreateInterestCategory("Development"));
            categories.Add(InterestCategory.CreateInterestCategory("Politics"));
            categories.Add(InterestCategory.CreateInterestCategory("Geopolitics and Area Studies"));
            categories.Add(InterestCategory.CreateInterestCategory("Rights and Minorities"));
            categories.Add(InterestCategory.CreateInterestCategory("Law"));
            categories.Add(InterestCategory.CreateInterestCategory("Employment"));
            categories.Add(InterestCategory.CreateInterestCategory("Economics and Finance"));
            categories.Add(InterestCategory.CreateInterestCategory("Good Governance"));
            categories.Add(InterestCategory.CreateInterestCategory("Democracy and Election"));
            categories.Add(InterestCategory.CreateInterestCategory("Crime and Security"));
            categories.Add(InterestCategory.CreateInterestCategory("Government"));
            categories.Add(InterestCategory.CreateInterestCategory("Economic Growth"));

            return categories;
        }

        private List<Interest> GenerateInterests(List<InterestCategory> categories)
        {
            var interests = new List<Interest>();
            var environments = new List<Interest>();
            var envCat = categories.Find(m => m.CategoryName == "Environment");

            environments.Add(Interest.CreateInterest("Environmental Policy"));
            environments.Add(Interest.CreateInterest("Environmental Science"));
            environments.Add(Interest.CreateInterest("Sustainability"));
            environments.Add(Interest.CreateInterest("Indigenous Issues"));
            environments.Add(Interest.CreateInterest("Access to Water"));

            foreach (var env in environments)
            {
                env.SetCategory(envCat);
                interests.Add(env);
            }

            var internationalRelations = new List<Interest>();
            var irCat = categories.Find(m => m.CategoryName == "International Relations");

            internationalRelations.Add(Interest.CreateInterest("International Relations"));
            internationalRelations.Add(Interest.CreateInterest("United Nations"));
            internationalRelations.Add(Interest.CreateInterest("European Union "));
            internationalRelations.Add(Interest.CreateInterest("World Bank"));
            internationalRelations.Add(Interest.CreateInterest("IMF"));

            foreach (var ir in internationalRelations)
            {
                ir.SetCategory(irCat);
                interests.Add(ir);
            }

            var globalSecurity = new List<Interest>();
            var gsCat = categories.Find(m => m.CategoryName == "Global Security");

            globalSecurity.Add(Interest.CreateInterest("International Security"));
            globalSecurity.Add(Interest.CreateInterest("Conflict"));
            globalSecurity.Add(Interest.CreateInterest("Civil War "));
            globalSecurity.Add(Interest.CreateInterest("Arms Trade"));

            foreach (var gs in globalSecurity)
            {
                gs.SetCategory(gsCat);
                interests.Add(gs);
            }

            var development = new List<Interest>();
            var devCat = categories.Find(m => m.CategoryName == "Development");

            development.Add(Interest.CreateInterest("Development"));
            development.Add(Interest.CreateInterest("International Development"));
            development.Add(Interest.CreateInterest("BRICS"));
            development.Add(Interest.CreateInterest("Foreign Aid"));
            development.Add(Interest.CreateInterest("Diplomacy"));

            foreach (var dev in development)
            {
                dev.SetCategory(devCat);
                interests.Add(dev);
            }

            var politics = new List<Interest>();
            var polCat = categories.Find(m => m.CategoryName == "Politics");

            politics.Add(Interest.CreateInterest("UK Politics"));
            politics.Add(Interest.CreateInterest("European Politics"));
            politics.Add(Interest.CreateInterest("US Politics"));
            politics.Add(Interest.CreateInterest("Global Politics"));

            foreach (var pol in politics)
            {
                pol.SetCategory(polCat);
                interests.Add(pol);
            }

            var geopolitics = new List<Interest>();
            var geoCat = categories.Find(m => m.CategoryName == "Geopolitics and Area Studies");

            geopolitics.Add(Interest.CreateInterest("Africa"));
            geopolitics.Add(Interest.CreateInterest("United States"));
            geopolitics.Add(Interest.CreateInterest("North America"));
            geopolitics.Add(Interest.CreateInterest("East Asia"));
            geopolitics.Add(Interest.CreateInterest("Middle East"));
            geopolitics.Add(Interest.CreateInterest("Latin America"));
            geopolitics.Add(Interest.CreateInterest("Russia and Central Asia"));

            foreach (var geo in geopolitics)
            {
                geo.SetCategory(geoCat);
                interests.Add(geo);
            }

            var rights = new List<Interest>();
            var rightsCat = categories.Find(m => m.CategoryName == "Rights and Minorities");

            rights.Add(Interest.CreateInterest("Human Rights"));
            rights.Add(Interest.CreateInterest("Race Issues"));
            rights.Add(Interest.CreateInterest("Minorities Rights"));
            rights.Add(Interest.CreateInterest("Children Rights"));

            foreach (var r in rights)
            {
                r.SetCategory(rightsCat);
                interests.Add(r);
            }

            var laws = new List<Interest>();
            var lawCat = categories.Find(m => m.CategoryName == "Law");

            laws.Add(Interest.CreateInterest("UK Law"));
            laws.Add(Interest.CreateInterest("European Law"));
            laws.Add(Interest.CreateInterest("International Law"));

            foreach (var l in laws)
            {
                l.SetCategory(lawCat);
                interests.Add(l);
            }

            var employment = new List<Interest>();
            var empCat = categories.Find(m => m.CategoryName == "Employment");

            employment.Add(Interest.CreateInterest("Job Creation"));
            employment.Add(Interest.CreateInterest("Employment"));
            employment.Add(Interest.CreateInterest("Workers Rights"));
            employment.Add(Interest.CreateInterest("Fairness in the Workplace"));

            foreach (var emp in employment)
            {
                emp.SetCategory(empCat);
                interests.Add(emp);
            }

            var economics = new List<Interest>();
            var econCat = categories.Find(m => m.CategoryName == "Economics and Finance");

            economics.Add(Interest.CreateInterest("Macroeconomics"));
            economics.Add(Interest.CreateInterest("Banking & Finance"));
            economics.Add(Interest.CreateInterest("Monetary Policy"));
            economics.Add(Interest.CreateInterest("Austerity"));
            economics.Add(Interest.CreateInterest("Investments"));
            economics.Add(Interest.CreateInterest("Business"));
            economics.Add(Interest.CreateInterest("Corporations"));

            foreach (var econ in economics)
            {
                econ.SetCategory(econCat);
                interests.Add(econ);
            }

            var goodGovs = new List<Interest>();
            var goodGovCat = categories.Find(m => m.CategoryName == "Good Governance");

            goodGovs.Add(Interest.CreateInterest("Governance"));
            goodGovs.Add(Interest.CreateInterest("Transparency"));
            goodGovs.Add(Interest.CreateInterest("Corruption"));

            foreach (var goodGov in goodGovs)
            {
                goodGov.SetCategory(goodGovCat);
                interests.Add(goodGov);
            }

            var democracies = new List<Interest>();
            var demoCat = categories.Find(m => m.CategoryName == "Democracy and Election");

            democracies.Add(Interest.CreateInterest(""));
            democracies.Add(Interest.CreateInterest("Voting Systems"));
            democracies.Add(Interest.CreateInterest("Electoral Reform"));
            democracies.Add(Interest.CreateInterest("Referendums"));
            democracies.Add(Interest.CreateInterest("Citizens Participation"));

            foreach (var demo in democracies)
            {
                demo.SetCategory(demoCat);
                interests.Add(demo);
            }

            var crimes = new List<Interest>();
            var crimeCat = categories.Find(m => m.CategoryName == "Crime and Security");

            crimes.Add(Interest.CreateInterest("Crime"));
            crimes.Add(Interest.CreateInterest("Organised Crime"));
            crimes.Add(Interest.CreateInterest("Drugs"));
            crimes.Add(Interest.CreateInterest("Drug Policy"));

            foreach (var c in crimes)
            {
                c.SetCategory(crimeCat);
                interests.Add(c);
            }

            var govs = new List<Interest>();
            var govCat = categories.Find(m => m.CategoryName == "Government");

            govs.Add(Interest.CreateInterest("Judiciary"));
            govs.Add(Interest.CreateInterest("Local Governments"));
            govs.Add(Interest.CreateInterest("Welfare"));
            govs.Add(Interest.CreateInterest("NHS"));

            foreach (var g in govs)
            {
                g.SetCategory(govCat);
                interests.Add(g);
            }

            var ecos = new List<Interest>();
            var ecoCat = categories.Find(m => m.CategoryName == "Economic Growth");

            ecos.Add(Interest.CreateInterest("Economic Growth"));
            ecos.Add(Interest.CreateInterest("Infrastructures"));
            ecos.Add(Interest.CreateInterest("Investments"));
            ecos.Add(Interest.CreateInterest("Taxes"));
            ecos.Add(Interest.CreateInterest("Bureaucracy"));
            ecos.Add(Interest.CreateInterest("Enterprise"));

            foreach (var e in ecos)
            {
                e.SetCategory(ecoCat);
                interests.Add(e);
            }

            return interests;
        }

        //private List<Gada.Discussions.Entities.Interest> GenerateDiscussionInterests()
        //{
        //    var interests = new List<Gada.Discussions.Entities.Interest>();
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Environment"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Environmental policy"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Environmental science"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Sustainability"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Indigenous issues"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Access to water"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("International relations"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("International relations"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("United Nations"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("European Union "));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("World Bank"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("IMF"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Global Security"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("International security"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Conflict"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Civil war "));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Arms trade"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Development"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("International development"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("BRICS"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Foreign aid"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Diplomacy"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Politics"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("UK politics"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("European politics"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("US politics"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Global Politics"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Geopolitics and Area studies"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Africa"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("United States"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("North America"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("East Asia"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Middle East"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Latin America"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Russia and Central Asia"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Rights and minorities"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Human rights"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Race issues"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Minorities rights"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Children rights"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Law"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("UK Law"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("European law"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("International law"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Employment"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Job creation"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Employment"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Workers rights"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Fairness in the workplace"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Economics and finance"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Macroeconomics"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Banking & finance"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Monetary policy"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Austerity"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Investments"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Business"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Corporations"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Good governance"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Governance"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Transparency"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Corruption"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Democracy and election"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Voting systems"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Electoral reform"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Referendums"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Citizens participation"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Crime and security"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Crime"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Organised crime"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Drugs "));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Drug policy"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Government"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Judiciary"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Local governments"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Welfare"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("NHS"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Economic growth"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Infrastructures"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Investments"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Taxes"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Bureaucracy"));
        //    interests.Add(Gada.Discussions.Entities.Interest.CreateInterest("Enterprise"));

        //    return interests;
        //}
    }
}