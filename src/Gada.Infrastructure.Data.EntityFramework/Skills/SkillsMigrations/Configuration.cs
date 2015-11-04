namespace Gada.Infrastructure.Data.EntityFramework.Skills.SkillsMigrations
{
    using Gada.Skills.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Gada.Infrastructure.Data.EntityFramework.Skills.SkillsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Skills\SkillsMigrations";
        }

        protected override void Seed(Gada.Infrastructure.Data.EntityFramework.Skills.SkillsContext context)
        {
            var skillCategories = GenerateSkillCategories();
            var skills = GenerateSkills(skillCategories);

            context.SkillCategories.AddRange(skillCategories);
            context.Skills.AddRange(skills);
            context.SaveChanges();
        }

        public List<SkillCategory> GenerateSkillCategories()
        {
            var categories = new List<SkillCategory>();
            categories.Add(SkillCategory.CreateSkillCategory("Research"));
            categories.Add(SkillCategory.CreateSkillCategory("Activism"));
            categories.Add(SkillCategory.CreateSkillCategory("Communication"));
            categories.Add(SkillCategory.CreateSkillCategory("Research"));
            categories.Add(SkillCategory.CreateSkillCategory("Various"));

            return categories;
        }

        public List<Skill> GenerateSkills(List<SkillCategory> categories)
        {
            var skills = new List<Skill>();

            var research = new List<Skill>();
            var resCat = categories.Find(m => m.CategoryName == "Research");

            research.Add(Skill.CreateSkill("Environment"));
            research.Add(Skill.CreateSkill("Law"));
            research.Add(Skill.CreateSkill("Economics"));
            research.Add(Skill.CreateSkill("Social Issues"));
            research.Add(Skill.CreateSkill("Human Rights"));
            research.Add(Skill.CreateSkill("Conflict"));
            research.Add(Skill.CreateSkill("Social Justice"));
            research.Add(Skill.CreateSkill("Sociology"));
            research.Add(Skill.CreateSkill("Politics"));
            research.Add(Skill.CreateSkill("International Issues"));

            foreach (var res in research)
            {
                res.SetCategory(resCat);
                skills.Add(res);
            }

            var activism = new List<Skill>();
            var actCat = categories.Find(m => m.CategoryName == "Activism");

            activism.Add(Skill.CreateSkill("Strategy"));
            activism.Add(Skill.CreateSkill("Campaign Building"));
            activism.Add(Skill.CreateSkill("Organising Action"));
            activism.Add(Skill.CreateSkill("Lobbying"));
            activism.Add(Skill.CreateSkill("UK Politics"));
            activism.Add(Skill.CreateSkill("European Politics"));
            activism.Add(Skill.CreateSkill("Connections in Government"));
            activism.Add(Skill.CreateSkill("Links with NGO's / Pressure Groups"));

            foreach (var act in activism)
            {
                act.SetCategory(actCat);
                skills.Add(act);
            }

            var communication = new List<Skill>();
            var commCat = categories.Find(m => m.CategoryName == "Communication");

            communication.Add(Skill.CreateSkill("Social Media"));
            communication.Add(Skill.CreateSkill("Mass Media"));
            communication.Add(Skill.CreateSkill("Strategic Communication"));
            communication.Add(Skill.CreateSkill("Media Relations"));
            communication.Add(Skill.CreateSkill("Public Speaking"));

            foreach (var comm in communication)
            {
                comm.SetCategory(commCat);
                skills.Add(comm);
            }

            var various = new List<Skill>();
            var varCat = categories.Find(m => m.CategoryName == "Various");

            various.Add(Skill.CreateSkill("Web Design/Development"));
            various.Add(Skill.CreateSkill("Writing"));
            various.Add(Skill.CreateSkill("Graphic Design"));
            various.Add(Skill.CreateSkill("PR and Networking"));
            various.Add(Skill.CreateSkill("Organisation and Management"));

            foreach (var v in various)
            {
                v.SetCategory(varCat);
                skills.Add(v);
            }

            return skills;
        }
    }
}
