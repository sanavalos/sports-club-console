using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsClubSystem {
    internal class SportsClub {
        private List<Activity> activities;
        private List<Member> members;

        public SportsClub() {
            this.activities = new List<Activity>();
            this.members = new List<Member>();
        }

        private Member? findMember(int uniqueId) {
            foreach (Member member in members) {
                if (member.UniqueId == uniqueId) {
                    return member;
                }
            }
            return null;
        }

        public bool membershipRegistration(String? name, int uniqueId) {
            bool result = false;
            Member? member = findMember(uniqueId);
            if (member == null) {
                member = new Member(name, uniqueId);
                members.Add(member);
                result = true;
            }

            return result;
        }

        private Activity? findActivity(String? name) {
            foreach (Activity activity in activities) {
                if (activity.Name != null && name != null) {
                    string activityOne = activity.Name.ToLower();
                    string activityTwo = name.ToLower();
                    if (activityOne == activityTwo) {
                        return activity;
                    }
                }
            }
            return null;
        }

        public bool createActivity(String? name, int quota) {
            bool result = false;
            Activity? activity = findActivity(name);

            if (activity == null) {
                activity = new Activity(name, quota);
                activities.Add(activity);
                result = true;
            }

            return result;
        }

        public string enrollMember(String? activityName, int memberIdNumber) {
            Member? member = findMember(memberIdNumber);

            if (member == null) {
                return "MEMBER NOT REGISTERED";
            }

            Activity? activity = findActivity(activityName);

            if (activity == null) {
                return "ACTIVITY NOT REGISTERED";
            }

            if (activity.Quota == 0) {
                return "NO QUOTA AVAILABLE";
            }

            if (member.Inscriptions.Count < 3) {
                activity.Quota -= 1;
                member.Inscriptions.Add(activity);
                return "ENROLLMENT SUCCESSFULL";
            } else {
                return "ACTIVITY QUOTA REACHED";
            }
        }

        public string ToStringActivities() {
            String result = "";
            foreach (Activity activity in activities) {
                result = result + activity.ToString() + "\n";
            }
            return result;
        }

        public string ToStringMembers() {
            String result = "";
            foreach (Member member in members) {
                result = result + member.ToString() + "\n";
            }
            return result;
        }

        public string registrationMessage(bool newEntry, string entityType, string entityName) {
            String registrationResponse = "";
            if (newEntry) {
                registrationResponse = $"{entityName} was added successfully!";
            } else {
                registrationResponse = $"{entityType} named {entityName} is already registered.";
            }
            return registrationResponse;
        }
    }
}
