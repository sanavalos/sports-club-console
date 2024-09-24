using SportsClubSystem;

String? option = "0";
SportsClub club = new SportsClub();


while (option != "9") {
    string menu = $"\n1. Create activity\n2. Register membership\n3. Enroll member in an activity\n4. Show activities\n5. Show members\n9. Exit\n";
    bool result;
    String activityName;
    int uniqueId;
    Console.WriteLine(menu);

    option = Console.ReadLine();

    switch (option) {
        case "1":
            Console.WriteLine("Enter the name of the activity:");
            activityName = Console.ReadLine();
            Console.WriteLine($"Enter the quota of {activityName}:");
            int quota = Convert.ToInt32(Console.ReadLine());
            result = club.createActivity(activityName, quota);
            String activityRegistration = club.registrationMessage(result, "activity", activityName);
            Console.WriteLine(activityRegistration);
            break;
        case "2":
            Console.WriteLine("Enter the name of the member:");
            String memberName = Console.ReadLine();
            Console.WriteLine("Enter the member\'s ID:");
            uniqueId = Convert.ToInt32(Console.ReadLine());
            result = club.membershipRegistration(memberName, uniqueId);
            String memberRegistration = club.registrationMessage(result, "member", memberName);
            Console.WriteLine(memberRegistration);
            break;
        case "3":
            Console.WriteLine("Enter the name of the activity:");
            activityName = Console.ReadLine();
            Console.WriteLine("Enter the member\'s ID:");
            uniqueId = Convert.ToInt32(Console.ReadLine());
            String response = club.enrollMember(activityName, uniqueId);
            Console.WriteLine(response);
            break;
        case "4":
            Console.WriteLine(club.ToStringActivities());
            break;
        case "5":
            Console.WriteLine(club.ToStringMembers());
            break;
        case "9":
            Console.WriteLine("Data entry completed.");
            break;
        default:
            Console.WriteLine("Invalid command. Please try again.");
            break;
    }
}

